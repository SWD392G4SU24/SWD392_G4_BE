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
            builder.HasKey(k => k.ID);

            builder.Property(p => p.Note).HasMaxLength(50)
                .IsRequired(false);

            // Foreign key for Promotion

            // Foreign key for Counter
            builder.HasOne(po => po.Counter).WithMany(od => od.Orders)
                .HasForeignKey(o => o.PromotionID).OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}