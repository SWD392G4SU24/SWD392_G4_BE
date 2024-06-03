using JewelrySalesSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Tept;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Infrastructure.Persistence.Configurations
{
    public class PromotionConfiguration : IEntityTypeConfiguration<PromotionEntity>
    {
       public void Configure(EntityTypeBuilder<PromotionEntity> builder)
        {

            builder.Property(k => k.ID).HasColumnName("VoucherCode");

            builder.Property(p => p.ConditionsOfUse).HasColumnType("decimal(18, 2)")
                .IsRequired();

            builder.Property(p => p.MaximumReduce).HasColumnType("decimal(18, 2)")
                .IsRequired();

        }
    }
}
