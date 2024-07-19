using JewelrySalesSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Infrastructure.Persistence.Configurations
{
    public class FormConfiguration : IEntityTypeConfiguration<FormEntity>
    {
        public void Configure(EntityTypeBuilder<FormEntity> builder)
        {
            builder.Property(e => e.Status)
                .HasConversion(v => v.ToString()
                , v => (FormStatus)Enum.Parse(typeof(FormStatus), v));
            builder.Property(e => e.Type)
                .HasConversion(v => v.ToString()
                , v => (FormType)Enum.Parse(typeof(FormType), v));
            builder.HasOne(e => e.Creator)
                .WithMany()
                .HasForeignKey(e => e.CreatorID)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
