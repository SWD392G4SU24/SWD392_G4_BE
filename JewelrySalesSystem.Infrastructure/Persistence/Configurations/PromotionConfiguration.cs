using JewelrySalesSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Infrastructure.Persistence.Configurations
{
    public class PromotionConfiguration : IEntityTypeConfiguration<PromotionEntity>
    {
        public void Configure(EntityTypeBuilder<PromotionEntity> builder)
        {

            builder.Property(po => po.ID).HasColumnName("VoucherCode");
            builder.Property(po => po.ConditionsOfUse).HasColumnType("decimal(18, 2)")
                .IsRequired();
            builder.Property(po => po.MaximumReduce).HasColumnType("decimal(18, 2)")
                .IsRequired();
            builder.Property(po => po.Description).HasMaxLength(255);
            builder.Property(e => e.Status)
                .HasConversion(v => v.ToString()
                , v => (PromotionStatus)Enum.Parse(typeof(PromotionStatus), v));
        }
    }
}
