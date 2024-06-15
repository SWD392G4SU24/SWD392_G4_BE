using JewelrySalesSystem.Domain.Entities.Configured;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Infrastructure.Persistence.Configurations.ConfigEntity
{
    public class DiamonConfiguration : IEntityTypeConfiguration<DiamonEntity>
    {
        public void Configure(EntityTypeBuilder<DiamonEntity> builder)
        {
            builder.HasKey(k => k.ID).HasName("DiamonID");
            builder.Property(k => k.Name).HasColumnName("DiamonType");
            builder.Property(k => k.CreatedAt).HasColumnName("Date");

            builder.Ignore(k => k.CreatorID);
            builder.Ignore(k => k.DeletedAt);
            builder.Ignore(k => k.DeleterID);
            builder.Ignore(k => k.UpdaterID);
            builder.Ignore(k => k.LastestUpdateAt);
        }
    }
}
