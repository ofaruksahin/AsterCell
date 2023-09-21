using AsterCell.Persistence.Common;
using Asterisk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Asterisk.Persistence
{
    public class AsteriskDbContext : AuditableDbContext
    {
        public AsteriskDbContext(DbContextOptions<AsteriskDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AsteriskDbContext).Assembly);
        }

        public DbSet<Endpoint> Endpoints { get; set; }
        public DbSet<EndpointAor> EndpointAors { get; set; }
        public DbSet<EndpointAuth> EndpointAuths { get; set; }
    }
}
