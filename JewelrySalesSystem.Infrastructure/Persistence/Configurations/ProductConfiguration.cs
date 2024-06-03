using JewelrySalesSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {

            builder.Property(po => po.ID).HasColumnName("ProductID");

            builder.Property(p => p.Cost).HasColumnType("decimal(18, 2)")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(255)
                .IsRequired(false);

        }
    }
}
