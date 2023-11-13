using Asterisk.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asterisk.Persistence.Configurations
{
    public class EndpointAorEntityTypeConfiguration : IEntityTypeConfiguration<EndpointAor>
    {
        public void Configure(EntityTypeBuilder<EndpointAor> builder)
        {
            builder.HasKey(f => f.Id);

            builder
                .Property(f => f.Id)
                .HasColumnType("varchar")
                .HasColumnName("id")
                .HasMaxLength(40)
                .IsRequired();

            builder
                .Property(f => f.MaxContacts)
                .HasColumnType("int")
                .HasColumnName("max_contacts")
                .IsRequired();

            builder
                .Property(f => f.RemoveExisting)
                .HasColumnType("varchar")
                .HasColumnName("remove_existing")
                .HasMaxLength(3)
                .IsRequired();

            builder.ToTable("ps_aors");
        }
    }
}
