using JewelrySalesSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelrySalesSystem.Infrastructure.Persistence.Configurations.ConfigEntity
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {

            builder.Property(po => po.Note).HasMaxLength(255).IsRequired();

        }
    }
}