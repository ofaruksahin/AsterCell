using Asterisk.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asterisk.Persistence.Configurations
{
    public class EndpointAuthEntityTypeConfiguration : IEntityTypeConfiguration<EndpointAuth>
    {
        public void Configure(EntityTypeBuilder<EndpointAuth> builder)
        {
            builder.HasNoKey();

            builder
                .Property(f => f.Id)
                .HasColumnType("varchar")
                .HasColumnName("id")
                .HasMaxLength(40)
                .IsRequired();

            builder
                .Property(f => f.AuthType)
                .HasColumnType("varchar")
                .HasColumnName("auth_type")
                .HasMaxLength(11)
                .IsRequired();

            builder
                .Property(f => f.Password)
                .HasColumnType("varchar")
                .HasColumnName("password")
                .HasMaxLength(80)
                .IsRequired();

            builder
                .Property(f => f.Username)
                .HasColumnType("varchar")
                .HasColumnName("username")
                .HasMaxLength(40)
                .IsRequired();

            builder.ToTable("ps_auths");
        }
    }
}
