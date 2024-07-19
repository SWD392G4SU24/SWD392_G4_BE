using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JewelrySalesSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdaterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastestUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Diamond",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiamondType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("DiamondID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Gold",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KaraContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoldContent = table.Column<float>(type: "real", nullable: false),
                    BuyCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GoldType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("GoldID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdaterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastestUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdaterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastestUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("RoleID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Counter",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdaterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastestUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CounterID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Counter_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WageCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GoldWeight = table.Column<float>(type: "real", nullable: true),
                    GoldID = table.Column<int>(type: "int", nullable: true),
                    DiamondID = table.Column<int>(type: "int", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CreatorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdaterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastestUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Diamond_DiamondID",
                        column: x => x.DiamondID,
                        principalTable: "Diamond",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Product_Gold_GoldID",
                        column: x => x.GoldID,
                        principalTable: "Gold",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    CounterID = table.Column<int>(type: "int", nullable: true),
                    CreatorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdaterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastestUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Counter_CounterID",
                        column: x => x.CounterID,
                        principalTable: "Counter",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Users_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailVerification",
                columns: table => new
                {
                    EmailVerificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailVerification", x => x.EmailVerificationId);
                    table.ForeignKey(
                        name: "FK_EmailVerification_Users_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppoinmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdaterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastestUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Forms_Users_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VoucherCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CounterID = table.Column<int>(type: "int", nullable: true),
                    BuyerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentMethodID = table.Column<int>(type: "int", nullable: false),
                    CreatorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdaterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastestUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Order_Counter_CounterID",
                        column: x => x.CounterID,
                        principalTable: "Counter",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Order_PaymentMethod_PaymentMethodID",
                        column: x => x.PaymentMethodID,
                        principalTable: "PaymentMethod",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Users_BuyerID",
                        column: x => x.BuyerID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    DetailID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GoldSellCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GoldBuyCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiamondSellCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdaterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastestUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.DetailID);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    VoucherCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConditionsOfUse = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReducedPercent = table.Column<float>(type: "real", nullable: false),
                    MaximumReduce = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExchangePoint = table.Column<int>(type: "int", nullable: false),
                    ExpiresTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrderID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdaterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastestUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.VoucherCode);
                    table.ForeignKey(
                        name: "FK_Promotion_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Promotion_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "ID", "CreatedAt", "CreatorID", "DeletedAt", "DeleterID", "LastestUpdateAt", "Name", "UpdaterID" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, "Vòng cổ", null },
                    { 2, null, null, null, null, null, "Vòng tay", null },
                    { 3, null, null, null, null, null, "Nhẫn", null },
                    { 4, null, null, null, null, null, "Đồng hồ", null },
                    { 5, null, null, null, null, null, "Bông tai", null },
                    { 6, null, null, null, null, null, "Kiềng", null },
                    { 7, null, null, null, null, null, "Lắc", null }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethod",
                columns: new[] { "ID", "CreatedAt", "CreatorID", "DeletedAt", "DeleterID", "LastestUpdateAt", "Name", "UpdaterID" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, "VnPay", null },
                    { 2, null, null, null, null, null, "COD", null }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "ID", "CreatedAt", "CreatorID", "DeletedAt", "DeleterID", "LastestUpdateAt", "Name", "UpdaterID" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, "Admin", null },
                    { 2, null, null, null, null, null, "Manager", null },
                    { 3, null, null, null, null, null, "Customer", null },
                    { 4, null, null, null, null, null, "Staff", null }
                });

            migrationBuilder.InsertData(
                table: "Counter",
                columns: new[] { "ID", "CategoryID", "CreatedAt", "CreatorID", "DeletedAt", "DeleterID", "LastestUpdateAt", "Name", "UpdaterID" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, null, null, "Quầy Vòng cổ", null },
                    { 2, 2, null, null, null, null, null, "Quầy Vòng tay", null },
                    { 3, 3, null, null, null, null, null, "Quầy Nhẫn", null },
                    { 4, 4, null, null, null, null, null, "Quầy Đồng hồ", null },
                    { 5, 5, null, null, null, null, null, "Quầy Bông tai", null },
                    { 6, 6, null, null, null, null, null, "Quầy Kiềng", null },
                    { 7, 7, null, null, null, null, null, "Quầy Lắc", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Address", "CounterID", "CreatedAt", "CreatorID", "DeletedAt", "DeleterID", "Email", "FullName", "LastestUpdateAt", "PasswordHash", "PhoneNumber", "Point", "RoleID", "Status", "UpdaterID", "Username" },
                values: new object[,]
                {
                    { "108032be0bf74643b0b28b1f2f5d5b2a", "123 Admin St.", null, new DateTime(2024, 7, 19, 9, 32, 24, 396, DateTimeKind.Local).AddTicks(1064), null, null, null, "admin@gmail.com", "Administrator", new DateTime(2024, 7, 19, 9, 32, 24, 396, DateTimeKind.Local).AddTicks(1064), "$2a$11$fE011t0YSF.CFpQ83MnA9u.fhh/RwCcm8Pv2EUCNyOX3Le1KqEHmC", "1234567890", 0, 1, "VERIFIED", null, "admin" },
                    { "9b0c4fa953f84cabae42f901ba93496c", "123 Staff St.", null, new DateTime(2024, 7, 19, 9, 32, 24, 920, DateTimeKind.Local).AddTicks(1961), null, null, null, "staff@gmail.com", "Staff", new DateTime(2024, 7, 19, 9, 32, 24, 920, DateTimeKind.Local).AddTicks(1961), "$2a$11$2nYuwqp.FS1gzFBWl5iZ3.Ev6NEXQUu/bMMVw1jJR1nZ9aVgaLjbq", "7234567890", 0, 4, "VERIFIED", null, "staff" },
                    { "abe63fbc57ed476ba5dd3184c1ab1fcd", "123 Manager St.", null, new DateTime(2024, 7, 19, 9, 32, 24, 563, DateTimeKind.Local).AddTicks(2706), null, null, null, "manager@gmail.com", "Manager", new DateTime(2024, 7, 19, 9, 32, 24, 563, DateTimeKind.Local).AddTicks(2706), "$2a$11$qcoGdv2.KMiOYaSa2rE9b.8WP2vQqL5h5VDj4y92M9b2peDgzfQeO", "2234567890", 0, 2, "VERIFIED", null, "manager" },
                    { "ce754321f37f4863a90c6bb5ae6fecf7", "Vinhomes GP", null, new DateTime(2024, 7, 19, 9, 32, 24, 742, DateTimeKind.Local).AddTicks(836), null, null, null, "phannam151@gmail.com", "Phan Hai Nam", new DateTime(2024, 7, 19, 9, 32, 24, 742, DateTimeKind.Local).AddTicks(836), "$2a$11$EuHyzMQs9amLNXbZf0q7Ru1zqZGBvMtfXQ.SzQwSL.zL21Vwuw6be", "093221349", 0, 3, "VERIFIED", null, "phannam151" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Counter_CategoryID",
                table: "Counter",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerification_CustomerID",
                table: "EmailVerification",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_CreatorID",
                table: "Forms",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_BuyerID",
                table: "Order",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CounterID",
                table: "Order",
                column: "CounterID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentMethodID",
                table: "Order",
                column: "PaymentMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_VoucherCode",
                table: "Order",
                column: "VoucherCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderID",
                table: "OrderDetail",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductID",
                table: "OrderDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_DiamondID",
                table: "Product",
                column: "DiamondID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_GoldID",
                table: "Product",
                column: "GoldID");

            migrationBuilder.CreateIndex(
                name: "IX_Promotion_OrderID",
                table: "Promotion",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Promotion_UserID",
                table: "Promotion",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CounterID",
                table: "Users",
                column: "CounterID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Promotion_VoucherCode",
                table: "Order",
                column: "VoucherCode",
                principalTable: "Promotion",
                principalColumn: "VoucherCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Counter_Category_CategoryID",
                table: "Counter");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_BuyerID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotion_Users_UserID",
                table: "Promotion");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Counter_CounterID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_PaymentMethod_PaymentMethodID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Promotion_VoucherCode",
                table: "Order");

            migrationBuilder.DropTable(
                name: "EmailVerification");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Diamond");

            migrationBuilder.DropTable(
                name: "Gold");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Counter");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "Promotion");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
