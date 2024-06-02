using JewelrySalesSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelrySalesSystem.Infrastructure.Persistence.Configurations.ConfigEntity
{
    public class PromotionConfiguration : IEntityTypeConfiguration<PromotionEntity>
    {
        public void Configure(EntityTypeBuilder<PromotionEntity> builder)
        {
            builder.ToTable("Promotion");

            builder.HasKey(k => k.ID);

            builder.Property(p => p.ConditionsOfUse)
                .IsRequired();

            builder.Property(p => p.Description)
                .IsRequired(false);

            builder.Property(p => p.ReducedPercent)
                .IsRequired();

            builder.Property(p => p.ExpiresTime)
            .IsRequired();

            builder.Property(p => p.ExchangePoint)
                .IsRequired();

            builder.Property(p => p.MaximumReduce)
                .IsRequired();

            // Foreign key for User
            builder.HasOne(us => us.User).WithMany(po => po.Promotions).HasForeignKey(us => us.UserID)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

        }
    }
}
