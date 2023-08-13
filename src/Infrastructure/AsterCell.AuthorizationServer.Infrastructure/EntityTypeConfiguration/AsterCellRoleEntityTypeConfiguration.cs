using AsterCell.AuthorizationServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsterCell.AuthorizationServer.Infrastructure.EntityTypeConfiguration
{
    public class AsterCellRoleEntityTypeConfiguration : IEntityTypeConfiguration<AsterCellRole>
    {
        public void Configure(EntityTypeBuilder<AsterCellRole> builder)
        {
            builder
                .Property(f => f.TenantId)
                .HasMaxLength(12);
        }
    }
}
