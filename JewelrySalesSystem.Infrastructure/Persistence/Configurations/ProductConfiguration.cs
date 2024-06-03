using JewelrySalesSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelrySalesSystem.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {

            builder.Property(po => po.ID).HasColumnName("ProductID");
            builder.Property(po => po.Cost).HasColumnType("decimal(18, 2)");
       
        }
    }
}
