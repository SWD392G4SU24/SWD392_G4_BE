using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Infrastructure.Persistence.Configurations;
using JewelrySalesSystem.Infrastructure.Persistence.Configurations.ConfigEntity;
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
        public DbSet<PromotionEntity> Promotions { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderDetailEntity> OrderDetails  { get; set; }
        public DbSet<CounterEntity> Counters { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<PaymentMethodEntity> PaymentMethods { get; set; }
        public DbSet<GoldEntity> Golds { get; set; }
        public DbSet<DiamondEntity> Diamonds { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // apply Config ở đây
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfigurtaion());
            modelBuilder.ApplyConfiguration(new CounterConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new DiamondConfiguration());
            modelBuilder.ApplyConfiguration(new GoldConfiguration());
            ConfigureModel(modelBuilder);
        }
        private void ConfigureModel(ModelBuilder modelBuilder)
        {


        }
    }
}