using JewelrySalesSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(k => k.ID);

            builder.Property(p => p.Note).HasMaxLength(50)
                .IsRequired();

            // Foreign key for Promotion
            builder.HasOne(po => po.Promotion).WithMany(o => o.Orders).HasForeignKey(po => po.PromotionID)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();


            // Foreign key for Counter
            builder.HasOne(co => co.Counter).WithMany(od => od.Orders).HasForeignKey(co => co.CounterID)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            // Foreign key for User
            builder.HasOne(us => us.User).WithMany(od => od.Orders).HasForeignKey(us => us.UserID)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();


        }
    }
}
