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
        public DbSet<UsersEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }  
        public DbSet<ProductEntity> Products { get; set; }  
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsersEntity>(entity =>
            {
                entity.HasKey(x => x.ID);

                entity.Property(x => x.Username).HasColumnType("nvarchar(50)").HasMaxLength(50);
            });

            // apply Config ở đây
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            ConfigureModel(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            ConfigureModel(modelBuilder);
        }
        private void ConfigureModel(ModelBuilder modelBuilder)
        {


        }
    }
}
