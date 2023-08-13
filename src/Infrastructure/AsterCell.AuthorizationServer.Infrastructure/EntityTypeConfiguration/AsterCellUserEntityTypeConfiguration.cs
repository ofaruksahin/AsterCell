using AsterCell.AuthorizationServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsterCell.AuthorizationServer.Infrastructure.EntityTypeConfiguration
{
    public class AsterCellUserEntityTypeConfiguration : IEntityTypeConfiguration<AsterCellUser>
    {
        public void Configure(EntityTypeBuilder<AsterCellUser> builder)
        {
            builder
                .Property(f => f.TenantId)
                .HasMaxLength(12)
                .IsRequired();
        }
    }
}
