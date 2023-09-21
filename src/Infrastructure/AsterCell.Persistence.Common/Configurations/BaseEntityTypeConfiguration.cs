using AsterCell.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsterCell.Persistence.Common.Configurations
{
    public class BaseEntityTypeConfiguration<TEntity, TId>
        : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity<TId>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(f => f.Id);

            builder
                .Property(f => f.Id)
                .IsRequired();

            builder
                .Property(f => f.CreatedAt)
                .IsRequired();

            builder
                .Property(f => f.UpdatedAt)
                .IsRequired();

            builder
                .Property(f => f.CreateUser)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(f => f.ModifyUser)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(f => f.Status)
                .IsRequired();

            builder
                .Ignore(f => f.DomainEvents);
        }
    }
}
