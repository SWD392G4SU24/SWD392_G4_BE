using JewelrySalesSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            
            builder.Property(po => po.Note).HasMaxLength(255);
            builder.Property(po => po.PromotionID).HasColumnName("VoucherCode");
            builder.Property(e => e.Status)
                .HasConversion(v => v.ToString()
                ,v => (OrderStatus)Enum.Parse(typeof(OrderStatus), v));
            builder.Property(e => e.Type)
                .HasConversion(v => v.ToString()
                , v => (OrderType)Enum.Parse(typeof(OrderType), v));
        }
    }
}