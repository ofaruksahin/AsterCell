using AsterCell.Domain.Models;
using AsterCell.Persistence.Common;
using Microsoft.EntityFrameworkCore;

namespace AsterCell.Persistence
{
    public class AsterCellDbContext : AuditableDbContext
    {
        public AsterCellDbContext(DbContextOptions<AsterCellDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AsterCellDbContext).Assembly);
        }

        public DbSet<Extension> Extensions { get; set; }
    }
}
