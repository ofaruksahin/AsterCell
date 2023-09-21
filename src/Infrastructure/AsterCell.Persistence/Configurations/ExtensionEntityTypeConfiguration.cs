using AsterCell.Domain.Models;
using AsterCell.Persistence.Common.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsterCell.Persistence.Configurations
{
    public class ExtensionEntityTypeConfiguration : BaseEntityTypeConfiguration<Extension, int>
    {
        public override void Configure(EntityTypeBuilder<Extension> builder)
        {
            base.Configure(builder);

            builder
                .Property(f => f.TenantId)
                .HasMaxLength(12)
                .IsRequired();

            builder
                .Property(f => f.Exten)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(f => f.ExtenNormalized)
                .HasMaxLength(113)
                .IsRequired();

            builder
                .Property(f => f.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(f => f.Description)
                .HasMaxLength(100)
                .IsRequired();

            builder.ToTable("extensions");
        }
    }
}
