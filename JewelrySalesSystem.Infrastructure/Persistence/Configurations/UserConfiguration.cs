using JewelrySalesSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasIndex(x => x.PhoneNumber)
                .IsUnique();
            builder.HasIndex(x => x.Email)
                .IsUnique();
            builder.Property(e => e.Status)
                .HasConversion(v => v.ToString()
                , v => (UserStatus)Enum.Parse(typeof(UserStatus), v));
        }
    }
}
