using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelrySalesSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhuyenMai",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DieuKienSuDung = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhanTramGiam = table.Column<float>(type: "real", nullable: false),
                    GiamToiDa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiemDoiThuong = table.Column<int>(type: "int", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMai", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PhanLoai",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanLoai", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMaiEntityPhanLoaiEntity",
                columns: table => new
                {
                    KhuyenMaisID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhanLoaisID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMaiEntityPhanLoaiEntity", x => new { x.KhuyenMaisID, x.PhanLoaisID });
                    table.ForeignKey(
                        name: "FK_KhuyenMaiEntityPhanLoaiEntity_KhuyenMai_KhuyenMaisID",
                        column: x => x.KhuyenMaisID,
                        principalTable: "KhuyenMai",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhuyenMaiEntityPhanLoaiEntity_PhanLoai_PhanLoaisID",
                        column: x => x.PhanLoaisID,
                        principalTable: "PhanLoai",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GiaSanPham = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrongLuong = table.Column<float>(type: "real", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhanLoaiID = table.Column<int>(type: "int", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SanPham_PhanLoai_PhanLoaiID",
                        column: x => x.PhanLoaiID,
                        principalTable: "PhanLoai",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoVaTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiemThuong = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMaiEntityUsersEntity",
                columns: table => new
                {
                    KhuyenMaisID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsersID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMaiEntityUsersEntity", x => new { x.KhuyenMaisID, x.UsersID });
                    table.ForeignKey(
                        name: "FK_KhuyenMaiEntityUsersEntity_KhuyenMai_KhuyenMaisID",
                        column: x => x.KhuyenMaisID,
                        principalTable: "KhuyenMai",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhuyenMaiEntityUsersEntity_Users_UsersID",
                        column: x => x.UsersID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KhuyenMaiEntityPhanLoaiEntity_PhanLoaisID",
                table: "KhuyenMaiEntityPhanLoaiEntity",
                column: "PhanLoaisID");

            migrationBuilder.CreateIndex(
                name: "IX_KhuyenMaiEntityUsersEntity_UsersID",
                table: "KhuyenMaiEntityUsersEntity",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_PhanLoaiID",
                table: "SanPham",
                column: "PhanLoaiID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhuyenMaiEntityPhanLoaiEntity");

            migrationBuilder.DropTable(
                name: "KhuyenMaiEntityUsersEntity");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "KhuyenMai");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PhanLoai");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
