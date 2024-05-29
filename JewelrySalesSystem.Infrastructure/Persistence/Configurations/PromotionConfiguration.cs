using JewelrySalesSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Tept;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Infrastructure.Persistence.Configurations
{
    public class PromotionConfiguration : IEntityTypeConfiguration<PromotionEntity>
    {
       public void Configure(EntityTypeBuilder<PromotionEntity> builder)
        {
            builder.HasKey(k => k.ID);
            builder.Property(p => p.ConditionsOfUse)
                .IsRequired();
            builder.Property(p => p.ReducedPercent)
                .IsRequired();
            builder.Property(p => p.ExpiresTime)
            .IsRequired();
            builder.Property(p => p.ExchangePoint)
                .IsRequired();
            builder.Property(p => p.MaximumReduce)
                .IsRequired();

        }
    }
}
