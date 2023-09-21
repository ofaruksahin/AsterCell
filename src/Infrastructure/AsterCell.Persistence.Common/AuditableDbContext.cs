using AsterCell.Application.Common.Contracts;
using AsterCell.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace AsterCell.Persistence.Common
{
    public class AuditableDbContext : DbContext, IUnitOfWork
    {
        public AuditableDbContext(DbContextOptions options) : base (options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async virtual Task<bool> CompleteTransaction(string user = "SYSTEM")
        {
            var entries = ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
            foreach (var entry in entries)
            {
                entry.Entity.ModifyUser = user;
                entry.Entity.UpdatedAt = DateTime.Now;

                if(entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.Now;
                    entry.Entity.CreateUser = user;
                }
            }

            var result = await base.SaveChangesAsync() > 0;

            return result;
        }
    }
}
