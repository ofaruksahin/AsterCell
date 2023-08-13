using AsterCell.AuthorizationServer.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AsterCell.AuthorizationServer.Infrastructure
{
    public class AsterCellAuthorizationDbContext : IdentityDbContext<AsterCellUser,AsterCellRole,int>
    {
        public AsterCellAuthorizationDbContext(DbContextOptions<AsterCellAuthorizationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
