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
    public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.HasKey(k => k.ID).HasName("RoleID");

            builder.Property(p => p.Name)
                .IsRequired();

            builder.Property(p => p.CreatorID);
            builder.Property(p => p.CreatedAt);
            builder.Property(p => p.UpdaterID);
            builder.Property(p => p.LastestUpdateAt);
            builder.Property(p => p.DeleterID);
            builder.Property(p => p.DeletedAt);
        }
    }
}
