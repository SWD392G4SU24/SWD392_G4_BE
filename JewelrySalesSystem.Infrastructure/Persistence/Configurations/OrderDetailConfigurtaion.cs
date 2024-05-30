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
    public class OrderDetailConfigurtaion : IEntityTypeConfiguration<OrderDetailEntity>
    {
        public void Configure(EntityTypeBuilder<OrderDetailEntity> builder)
        {
            builder.HasKey(k => k.ID);
            // Foreign key for Order
            builder.HasOne(o => o.Order).WithMany(o => o.OrderDetails).HasForeignKey(o => o.OrderID).OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            // Foreign key for Product
            builder.HasOne(o => o.Product).WithMany(o => o.OrderDetails).HasForeignKey(o => o.ProductID).OnDelete(DeleteBehavior.Restrict)
               .IsRequired();
        }
    }
}
