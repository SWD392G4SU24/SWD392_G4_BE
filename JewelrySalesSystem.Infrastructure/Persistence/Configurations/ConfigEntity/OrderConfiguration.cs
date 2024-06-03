using JewelrySalesSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelrySalesSystem.Infrastructure.Persistence.Configurations.ConfigEntity
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {

            builder.Property(po => po.Note).HasMaxLength(255)
                .IsRequired();
            builder.Property(po => po.PromotionID).HasColumnName("VoucherCode")
                .IsRequired();
            builder.Property(po => po.CounterID);
            builder.Property(po => po.UserID)
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