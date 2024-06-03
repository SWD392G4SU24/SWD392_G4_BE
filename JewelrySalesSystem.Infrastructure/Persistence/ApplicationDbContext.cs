using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //khai báo dbSet ở đây
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<PromotionEntity> Promotes { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderDetailEntity> OrderDetails  { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // apply Config ở đây
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            ConfigureModel(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            ConfigureModel(modelBuilder);
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            ConfigureModel(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            ConfigureModel(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrderDetailConfigurtaion());
            ConfigureModel(modelBuilder);
        }
        private void ConfigureModel(ModelBuilder modelBuilder)
        {


        }
    }
}
