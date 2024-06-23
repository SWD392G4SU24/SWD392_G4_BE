﻿// <auto-generated />
using System;
using JewelrySalesSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JewelrySalesSystem.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.Configured.CategoryEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastestUpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdaterID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.Configured.CounterEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastestUpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdaterID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID")
                        .HasName("CounterID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Counter");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.Configured.DiamondEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("BuyCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DiamondType");

                    b.Property<decimal>("SellCost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID")
                        .HasName("DiamondID");

                    b.ToTable("Diamond");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.Configured.GoldEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("BuyCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<float>("GoldContent")
                        .HasColumnType("real");

                    b.Property<float>("KaraContent")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("GoldType");

                    b.Property<decimal>("SellCost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID")
                        .HasName("GoldID");

                    b.ToTable("Gold");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.Configured.PaymentMethodEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastestUpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdaterID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("PaymentMethod");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.Configured.RoleEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastestUpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdaterID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID")
                        .HasName("RoleID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.OrderDetailEntity", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("DetailID");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("DiamondSellCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("GoldBuyCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("GoldSellCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("LastestUpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("ProductCost")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ProductID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("UpdaterID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.OrderEntity", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BuyerID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("CounterID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastestUpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("PaymentMethodID")
                        .HasColumnType("int");

                    b.Property<string>("PromotionID")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("VoucherCode");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdaterID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BuyerID");

                    b.HasIndex("CounterID");

                    b.HasIndex("PaymentMethodID");

                    b.HasIndex("PromotionID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.ProductEntity", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DiamonType")
                        .HasColumnType("int");

                    b.Property<int?>("GoldType")
                        .HasColumnType("int");

                    b.Property<float?>("GoldWeight")
                        .HasColumnType("real");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastestUpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("UpdaterID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WageCost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("DiamonType");

                    b.HasIndex("GoldType");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.PromotionEntity", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("VoucherCode");

                    b.Property<decimal>("ConditionsOfUse")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ExchangePoint")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiresTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastestUpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("MaximumReduce")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<float>("ReducedPercent")
                        .HasColumnType("real");

                    b.Property<string>("UpdaterID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Promotion");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.UserEntity", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CounterID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastestUpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("UpdaterID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CounterID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("RoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.Configured.CounterEntity", b =>
                {
                    b.HasOne("JewelrySalesSystem.Domain.Entities.Configured.CategoryEntity", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.OrderDetailEntity", b =>
                {
                    b.HasOne("JewelrySalesSystem.Domain.Entities.OrderEntity", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JewelrySalesSystem.Domain.Entities.ProductEntity", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.OrderEntity", b =>
                {
                    b.HasOne("JewelrySalesSystem.Domain.Entities.UserEntity", "User")
                        .WithMany("Orders")
                        .HasForeignKey("BuyerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewelrySalesSystem.Domain.Entities.Configured.CounterEntity", "Counter")
                        .WithMany("Orders")
                        .HasForeignKey("CounterID");

                    b.HasOne("JewelrySalesSystem.Domain.Entities.Configured.PaymentMethodEntity", "PaymentMethod")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentMethodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewelrySalesSystem.Domain.Entities.PromotionEntity", "Promotion")
                        .WithMany("Orders")
                        .HasForeignKey("PromotionID");

                    b.Navigation("Counter");

                    b.Navigation("PaymentMethod");

                    b.Navigation("Promotion");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.ProductEntity", b =>
                {
                    b.HasOne("JewelrySalesSystem.Domain.Entities.Configured.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewelrySalesSystem.Domain.Entities.Configured.DiamondEntity", "Diamond")
                        .WithMany("Products")
                        .HasForeignKey("DiamonType");

                    b.HasOne("JewelrySalesSystem.Domain.Entities.Configured.GoldEntity", "Gold")
                        .WithMany("Products")
                        .HasForeignKey("GoldType");

                    b.Navigation("Category");

                    b.Navigation("Diamond");

                    b.Navigation("Gold");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.PromotionEntity", b =>
                {
                    b.HasOne("JewelrySalesSystem.Domain.Entities.UserEntity", "User")
                        .WithMany("Promotions")
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.UserEntity", b =>
                {
                    b.HasOne("JewelrySalesSystem.Domain.Entities.Configured.CounterEntity", "Counter")
                        .WithMany("Users")
                        .HasForeignKey("CounterID");

                    b.HasOne("JewelrySalesSystem.Domain.Entities.Configured.RoleEntity", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Counter");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.Configured.CategoryEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.Configured.CounterEntity", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.Configured.DiamondEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.Configured.GoldEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.Configured.PaymentMethodEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.Configured.RoleEntity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.OrderEntity", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.ProductEntity", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.PromotionEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Promotions");
                });
#pragma warning restore 612, 618
        }
    }
}
