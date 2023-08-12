using AsterCell.AuthenticationServer.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AsterCell.AuthenticationServer.Infrastructure
{
    public class AsterCellAuthenticationServerDbContext : IdentityDbContext<AsterCellUser, AsterCellRole, int>
    {
        public AsterCellAuthenticationServerDbContext(DbContextOptions<AsterCellAuthenticationServerDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=AsterCellAuthentication;User Id=sa;Password=123456789F@;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
