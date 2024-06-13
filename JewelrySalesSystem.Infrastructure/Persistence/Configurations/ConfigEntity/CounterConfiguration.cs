using JewelrySalesSystem.Domain.Entities.Configured;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Infrastructure.Persistence.Configurations.ConfigEntity
{
    public class CounterConfiguration : IEntityTypeConfiguration<CounterEntity>
    {
        public void Configure(EntityTypeBuilder<CounterEntity> builder)
        {
            builder.HasKey(k => k.ID).HasName("CounterID");
        }
    }
}
