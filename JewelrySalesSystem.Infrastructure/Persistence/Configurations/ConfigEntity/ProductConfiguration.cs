using JewelrySalesSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelrySalesSystem.Infrastructure.Persistence.Configurations.ConfigEntity
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {

            builder.Property(po => po.Cost).HasColumnType("decimal(18, 2)")
                .IsRequired();
            builder.Property(po => po.Weight)
                .IsRequired();
            builder.Property(po => po.Quantity)
                .IsRequired();
            builder.Property(po => po.Description)
                .IsRequired(false);
            builder.Property(po => po.CategoryID)
                .IsRequired();
            builder.HasIndex(po => po.CreatorID)
                .IsUnique();
            builder.HasIndex(po => po.CreatedAt)
                .IsUnique();
            builder.Property(po => po.DeleterID);
            builder.Property(po => po.DeletedAt);
            builder.Property(po => po.LastestUpdateAt);
            builder.Property(po => po.UpdaterID);

        }
    }
}
