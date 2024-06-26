﻿using JewelrySalesSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelrySalesSystem.Infrastructure.Persistence.Configurations
{
    public class OrderDetailConfigurtaion : IEntityTypeConfiguration<OrderDetailEntity>
    {
        public void Configure(EntityTypeBuilder<OrderDetailEntity> builder)
        {

            builder.Property(po => po.ID).HasColumnName("DetailID");           
            builder.Property(po => po.ProductCost).HasColumnType("decimal(18, 2)")
                .IsRequired();
            builder.HasOne(o => o.Order)
                   .WithMany(u => u.OrderDetails)
                   .HasForeignKey(o => o.OrderID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
