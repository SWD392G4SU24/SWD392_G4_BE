using JewelrySalesSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelrySalesSystem.Infrastructure.Persistence.Configurations.ConfigEntity
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
            builder.Property(po => po.ReducedPercent)
                .IsRequired();
            builder.Property(po => po.ExpiresTime)
                .IsRequired();
            builder.Property(po => po.ExchangePoint)
                .IsRequired();
            builder.Property(po => po.UserID);
            builder.HasIndex(po => po.CreatorID)
                .IsUnique();
            builder.HasIndex(po => po.CreatedAt)
                .IsUnique();
            builder.Property(po => po.DeleterID);
            builder.Property(po => po.DeletedAt);
            builder.Property(po => po.LastestUpdateAt);
            builder.Property(po => po.UpdaterID);

        }
    }
}
