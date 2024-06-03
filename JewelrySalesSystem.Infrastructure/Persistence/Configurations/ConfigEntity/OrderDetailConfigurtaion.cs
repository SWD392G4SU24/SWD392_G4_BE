using JewelrySalesSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelrySalesSystem.Infrastructure.Persistence.Configurations.ConfigEntity
{
    public class OrderDetailConfigurtaion : IEntityTypeConfiguration<OrderDetailEntity>
    {
        public void Configure(EntityTypeBuilder<OrderDetailEntity> builder)
        {

            builder.Property(po => po.ID).HasColumnName("ODetailID");
            builder.Property(po => po.OrderID)
                .IsRequired();
            builder.Property(po => po.ProductCost).HasColumnType("decimal(18, 2)")
                .IsRequired();
            builder.Property(po => po.ProductID)
                .IsRequired();
            builder.Property(po => po.Quantity)
                .IsRequired();
            builder.HasIndex(ct => ct.CreatorID)
                .IsUnique();
            builder.HasIndex(ct => ct.CreatedAt)
                .IsUnique();
            builder.Property(po => po.DeleterID);
            builder.Property(po => po.DeletedAt);
            builder.Property(po => po.LastestUpdateAt);
            builder.Property(po => po.UpdaterID);

        }
    }
}
