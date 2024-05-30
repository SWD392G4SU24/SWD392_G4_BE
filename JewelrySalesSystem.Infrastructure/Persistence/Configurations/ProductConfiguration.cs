using JewelrySalesSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Tept;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(k => k.ID);
            builder.Property(p => p.Cost).HasColumnType("float")
                .IsRequired();
            builder.Property(p => p.Weight).HasColumnType("float")
                .IsRequired();
            builder.Property(p => p.Quantity).HasColumnType("int")
                .IsRequired();
            builder.Property(p => p.Description).HasColumnType("string")
                .HasMaxLength(30).IsRequired();
            // Foreign Key for Catergory
            builder.HasOne(p => p.Category).WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryID).OnDelete(DeleteBehavior.Restrict)
                .IsRequired(); 
        }
    }
}
