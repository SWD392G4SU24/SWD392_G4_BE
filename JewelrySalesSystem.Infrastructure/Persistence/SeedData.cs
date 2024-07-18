using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Entities.Configured;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Infrastructure.Persistence
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleEntity>().HasData(
                    new RoleEntity {ID = 1, Name = "Admin" },
                    new RoleEntity {ID = 2, Name = "Manager" },
                    new RoleEntity {ID = 3, Name = "Customer" },
                    new RoleEntity {ID = 4, Name = "Staff" }
                );

            modelBuilder.Entity<PaymentMethodEntity>().HasData(
                    new PaymentMethodEntity { ID = 1, Name = "VnPay" },
                    new PaymentMethodEntity { ID = 2, Name = "COD" }
                );

            var categories = new List<CategoryEntity>
            {
                new CategoryEntity { ID = 1, Name = "Vòng cổ" },
                new CategoryEntity { ID = 2, Name = "Vòng tay" },
                new CategoryEntity { ID = 3, Name = "Nhẫn" },
                new CategoryEntity { ID = 4, Name = "Đồng hồ" },
                new CategoryEntity { ID = 5, Name = "Bông tai" },
                new CategoryEntity { ID = 6, Name = "Kiềng" },
                new CategoryEntity { ID = 7, Name = "Lắc" }
            };
            modelBuilder.Entity<CategoryEntity>().HasData(categories);

            var counters = categories.Select(category => new CounterEntity
            {
                ID = category.ID,
                Name = $"Quầy {category.Name}",
                CategoryID = category.ID
            }).ToList();
            modelBuilder.Entity<CounterEntity>().HasData(counters);

            // Seed admin account
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    ID = Guid.NewGuid().ToString("N"),
                    Username = "admin",
                    Email = "admin@gmail.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin"),
                    RoleID = 1,
                    FullName = "Administrator",
                    Address = "123 Admin St.",
                    PhoneNumber = "1234567890",
                    Point = 0,
                    Status = UserStatus.VERIFIED
                },

                // Seed manager account
                new UserEntity
                {
                    ID = Guid.NewGuid().ToString("N"),
                    Username = "manager",
                    Email = "manager@gmail.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("manager"),
                    RoleID = 2,
                    FullName = "Manager",
                    Address = "123 Manager St.",
                    PhoneNumber = "2234567890",
                    Point = 0,
                    Status = UserStatus.VERIFIED
                },

                // Seed customer account
                new UserEntity
                {
                    ID = Guid.NewGuid().ToString("N"),
                    Username = "phannam151",
                    Email = "phannam151@gmail.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("namdeptrai"),
                    RoleID = 3,
                    FullName = "Phan Hai Nam",
                    Address = "Vinhomes GP",
                    PhoneNumber = "093221349",
                    Point = 0,
                    Status = UserStatus.VERIFIED
                },

                // Seed staff account
                new UserEntity
                {
                    ID = Guid.NewGuid().ToString("N"),
                    Username = "staff",
                    Email = "staff@gmail.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("staff123"),
                    RoleID = 4,
                    FullName = "Staff",
                    Address = "123 Staff St.",
                    PhoneNumber = "7234567890",
                    Point = 0,
                    Status = UserStatus.VERIFIED
                });     
        }
    }
}
