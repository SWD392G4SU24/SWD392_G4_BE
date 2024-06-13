using JewelrySalesSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        }
    }
}
