﻿// <auto-generated />
using System;
using JewelrySalesSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JewelrySalesSystem.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240719023225_final")]
    partial class final
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

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Vòng cổ"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Vòng tay"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Nhẫn"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Đồng hồ"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Bông tai"
                        },
                        new
                        {
                            ID = 6,
                            Name = "Kiềng"
                        },
                        new
                        {
                            ID = 7,
                            Name = "Lắc"
                        });
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

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CategoryID = 1,
                            Name = "Quầy Vòng cổ"
                        },
                        new
                        {
                            ID = 2,
                            CategoryID = 2,
                            Name = "Quầy Vòng tay"
                        },
                        new
                        {
                            ID = 3,
                            CategoryID = 3,
                            Name = "Quầy Nhẫn"
                        },
                        new
                        {
                            ID = 4,
                            CategoryID = 4,
                            Name = "Quầy Đồng hồ"
                        },
                        new
                        {
                            ID = 5,
                            CategoryID = 5,
                            Name = "Quầy Bông tai"
                        },
                        new
                        {
                            ID = 6,
                            CategoryID = 6,
                            Name = "Quầy Kiềng"
                        },
                        new
                        {
                            ID = 7,
                            CategoryID = 7,
                            Name = "Quầy Lắc"
                        });
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

                    b.Property<string>("KaraContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "VnPay"
                        },
                        new
                        {
                            ID = 2,
                            Name = "COD"
                        });
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

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Manager"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Customer"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Staff"
                        });
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.EmailModel.EmailVerification", b =>
                {
                    b.Property<int>("EmailVerificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmailVerificationId"));

                    b.Property<string>("CustomerID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmailVerificationId");

                    b.HasIndex("CustomerID");

                    b.ToTable("EmailVerification");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.FormEntity", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AppoinmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastestUpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdaterID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CreatorID");

                    b.ToTable("Forms");
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

                    b.Property<DateTime?>("PickupDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PromotionID")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("VoucherCode");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<int?>("DiamondID")
                        .HasColumnType("int");

                    b.Property<int?>("GoldID")
                        .HasColumnType("int");

                    b.Property<float?>("GoldWeight")
                        .HasColumnType("real");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastestUpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("UpdaterID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WageCost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("DiamondID");

                    b.HasIndex("GoldID");

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

                    b.Property<string>("OrderID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("ReducedPercent")
                        .HasColumnType("real");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdaterID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

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

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.HasData(
                        new
                        {
                            ID = "108032be0bf74643b0b28b1f2f5d5b2a",
                            Address = "123 Admin St.",
                            CreatedAt = new DateTime(2024, 7, 19, 9, 32, 24, 396, DateTimeKind.Local).AddTicks(1064),
                            Email = "admin@gmail.com",
                            FullName = "Administrator",
                            LastestUpdateAt = new DateTime(2024, 7, 19, 9, 32, 24, 396, DateTimeKind.Local).AddTicks(1064),
                            PasswordHash = "$2a$11$fE011t0YSF.CFpQ83MnA9u.fhh/RwCcm8Pv2EUCNyOX3Le1KqEHmC",
                            PhoneNumber = "1234567890",
                            Point = 0,
                            RoleID = 1,
                            Status = "VERIFIED",
                            Username = "admin"
                        },
                        new
                        {
                            ID = "abe63fbc57ed476ba5dd3184c1ab1fcd",
                            Address = "123 Manager St.",
                            CreatedAt = new DateTime(2024, 7, 19, 9, 32, 24, 563, DateTimeKind.Local).AddTicks(2706),
                            Email = "manager@gmail.com",
                            FullName = "Manager",
                            LastestUpdateAt = new DateTime(2024, 7, 19, 9, 32, 24, 563, DateTimeKind.Local).AddTicks(2706),
                            PasswordHash = "$2a$11$qcoGdv2.KMiOYaSa2rE9b.8WP2vQqL5h5VDj4y92M9b2peDgzfQeO",
                            PhoneNumber = "2234567890",
                            Point = 0,
                            RoleID = 2,
                            Status = "VERIFIED",
                            Username = "manager"
                        },
                        new
                        {
                            ID = "ce754321f37f4863a90c6bb5ae6fecf7",
                            Address = "Vinhomes GP",
                            CreatedAt = new DateTime(2024, 7, 19, 9, 32, 24, 742, DateTimeKind.Local).AddTicks(836),
                            Email = "phannam151@gmail.com",
                            FullName = "Phan Hai Nam",
                            LastestUpdateAt = new DateTime(2024, 7, 19, 9, 32, 24, 742, DateTimeKind.Local).AddTicks(836),
                            PasswordHash = "$2a$11$EuHyzMQs9amLNXbZf0q7Ru1zqZGBvMtfXQ.SzQwSL.zL21Vwuw6be",
                            PhoneNumber = "093221349",
                            Point = 0,
                            RoleID = 3,
                            Status = "VERIFIED",
                            Username = "phannam151"
                        },
                        new
                        {
                            ID = "9b0c4fa953f84cabae42f901ba93496c",
                            Address = "123 Staff St.",
                            CreatedAt = new DateTime(2024, 7, 19, 9, 32, 24, 920, DateTimeKind.Local).AddTicks(1961),
                            Email = "staff@gmail.com",
                            FullName = "Staff",
                            LastestUpdateAt = new DateTime(2024, 7, 19, 9, 32, 24, 920, DateTimeKind.Local).AddTicks(1961),
                            PasswordHash = "$2a$11$2nYuwqp.FS1gzFBWl5iZ3.Ev6NEXQUu/bMMVw1jJR1nZ9aVgaLjbq",
                            PhoneNumber = "7234567890",
                            Point = 0,
                            RoleID = 4,
                            Status = "VERIFIED",
                            Username = "staff"
                        });
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

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.EmailModel.EmailVerification", b =>
                {
                    b.HasOne("JewelrySalesSystem.Domain.Entities.UserEntity", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.FormEntity", b =>
                {
                    b.HasOne("JewelrySalesSystem.Domain.Entities.UserEntity", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Creator");
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
                        .WithMany()
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
                        .HasForeignKey("DiamondID");

                    b.HasOne("JewelrySalesSystem.Domain.Entities.Configured.GoldEntity", "Gold")
                        .WithMany("Products")
                        .HasForeignKey("GoldID");

                    b.Navigation("Category");

                    b.Navigation("Diamond");

                    b.Navigation("Gold");
                });

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.PromotionEntity", b =>
                {
                    b.HasOne("JewelrySalesSystem.Domain.Entities.OrderEntity", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID");

                    b.HasOne("JewelrySalesSystem.Domain.Entities.UserEntity", "User")
                        .WithMany("Promotions")
                        .HasForeignKey("UserID");

                    b.Navigation("Order");

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

            modelBuilder.Entity("JewelrySalesSystem.Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Promotions");
                });
#pragma warning restore 612, 618
        }
    }
}
