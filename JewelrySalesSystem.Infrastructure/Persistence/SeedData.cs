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
                    new RoleEntity {ID = 1, Name = "Admin", CreatedAt = DateTime.UtcNow },
                    new RoleEntity {ID = 2, Name = "Manager", CreatedAt = DateTime.UtcNow },
                    new RoleEntity {ID = 3, Name = "Customer", CreatedAt = DateTime.UtcNow },
                    new RoleEntity {ID = 4, Name = "Staff", CreatedAt = DateTime.UtcNow }
                );

            modelBuilder.Entity<PaymentMethodEntity>().HasData(
                    new PaymentMethodEntity { ID = 1, Name = "VnPay", CreatedAt = DateTime.UtcNow },
                    new PaymentMethodEntity { ID = 2, Name = "COD", CreatedAt = DateTime.UtcNow }
                );

            // Seed admin account
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    ID = Guid.NewGuid().ToString("N"),
                    Username = "admin",
                    Email = "admin@gmail.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin"),
                    RoleID = 1,
                    CreatedAt = DateTime.Now,
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
                    CreatedAt = DateTime.Now,
                    FullName = "Manager",
                    Address = "123 Manager St.",
                    PhoneNumber = "2234567890",
                    Point = 0,
                    Status = UserStatus.VERIFIED
                });
        }
    }
}
