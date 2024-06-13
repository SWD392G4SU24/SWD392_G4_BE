﻿// <auto-generated />
using System;
using JewelrySalesSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JewelrySalesSystem.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240613093920_v2")]
    partial class v2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.Configured.CategoryEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatorID")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeleterID")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastestUpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UpdaterID")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.Configured.CounterEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatorID")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeleterID")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastestUpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UpdaterID")
                        .HasColumnType("text");

                    b.HasKey("ID")
                        .HasName("CounterID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Counter");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.Configured.PaymentMethodEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatorID")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeleterID")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastestUpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UpdaterID")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("PaymentMethod");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.Configured.RoleEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatorID")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeleterID")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastestUpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UpdaterID")
                        .HasColumnType("text");

                    b.HasKey("ID")
                        .HasName("RoleID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.OrderDetailEntity", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text")
                        .HasColumnName("DetailID");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatorID")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeleterID")
                        .HasColumnType("text");

                    b.Property<decimal?>("DiamondSellCost")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("GoldBuyCost")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("GoldSellCost")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("LastestUpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OrderID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ProductCost")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ProductID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("UpdaterID")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.OrderEntity", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<int?>("CounterID")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatorID")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeleterID")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastestUpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("PaymentMethodID")
                        .HasColumnType("integer");

                    b.Property<string>("PromotionID")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("VoucherCode");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("numeric");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UpdaterID")
                        .HasColumnType("text");

                    b.Property<string>("UserEntityID")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("CounterID");

                    b.HasIndex("PaymentMethodID");

                    b.HasIndex("PromotionID");

                    b.HasIndex("UserEntityID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.ProductEntity", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<int>("CategoryID")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatorID")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeleterID")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("DiamonType")
                        .HasColumnType("text");

                    b.Property<string>("GoldType")
                        .HasColumnType("text");

                    b.Property<float?>("GoldWeight")
                        .HasColumnType("real");

                    b.Property<string>("ImageURL")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastestUpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("UpdaterID")
                        .HasColumnType("text");

                    b.Property<decimal>("WageCost")
                        .HasColumnType("numeric");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.PromotionEntity", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text")
                        .HasColumnName("VoucherCode");

                    b.Property<decimal>("ConditionsOfUse")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatorID")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeleterID")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("ExchangePoint")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ExpiresTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("LastestUpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("MaximumReduce")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<float>("ReducedPercent")
                        .HasColumnType("real");

                    b.Property<string>("UpdaterID")
                        .HasColumnType("text");

                    b.Property<string>("UserID")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Promotion");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.UserEntity", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("CounterID")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatorID")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeleterID")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastestUpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<int>("Point")
                        .HasColumnType("integer");

                    b.Property<int>("RoleID")
                        .HasColumnType("integer");

                    b.Property<string>("UpdaterID")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

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
                    b.HasOne("JewelrySalesSystem.Domain.Entities.Configured.CounterEntity", "Counter")
                        .WithMany("Orders")
                        .HasForeignKey("CounterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewelrySalesSystem.Domain.Entities.Configured.PaymentMethodEntity", "PaymentMethod")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentMethodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewelrySalesSystem.Domain.Entities.PromotionEntity", "Promotion")
                        .WithMany("Orders")
                        .HasForeignKey("PromotionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewelrySalesSystem.Domain.Entities.UserEntity", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserEntityID");

                    b.Navigation("Counter");

                    b.Navigation("PaymentMethod");

                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.ProductEntity", b =>
                {
                    b.HasOne("JewelrySalesSystem.Domain.Entities.Configured.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
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
                        .HasForeignKey("CounterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
