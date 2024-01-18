using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initVanBanPhapLuat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoQuanBanHanh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhomCoQuan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenCoQuan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoQuanBanHanh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiVanBan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiVanBan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VanBanPhapLuat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoHieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayBanHanh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoQuanBanHanhId = table.Column<int>(type: "int", nullable: false),
                    LoaiVanBanId = table.Column<int>(type: "int", nullable: false),
                    TrichYeuNoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    NgayHieuLuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuongDanUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VanBanPhapLuat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VanBanPhapLuat_CoQuanBanHanh_CoQuanBanHanhId",
                        column: x => x.CoQuanBanHanhId,
                        principalTable: "CoQuanBanHanh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VanBanPhapLuat_LoaiVanBan_LoaiVanBanId",
                        column: x => x.LoaiVanBanId,
                        principalTable: "LoaiVanBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VanBanLienQuan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VanBanPhapLuatId = table.Column<int>(type: "int", nullable: false),
                    NgayBanHanh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VanBanLienQuan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VanBanLienQuan_VanBanPhapLuat_VanBanPhapLuatId",
                        column: x => x.VanBanPhapLuatId,
                        principalTable: "VanBanPhapLuat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VanBanLienQuan_VanBanPhapLuatId",
                table: "VanBanLienQuan",
                column: "VanBanPhapLuatId");

            migrationBuilder.CreateIndex(
                name: "IX_VanBanPhapLuat_CoQuanBanHanhId",
                table: "VanBanPhapLuat",
                column: "CoQuanBanHanhId");

            migrationBuilder.CreateIndex(
                name: "IX_VanBanPhapLuat_LoaiVanBanId",
                table: "VanBanPhapLuat",
                column: "LoaiVanBanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VanBanLienQuan");

            migrationBuilder.DropTable(
                name: "VanBanPhapLuat");

            migrationBuilder.DropTable(
                name: "CoQuanBanHanh");

            migrationBuilder.DropTable(
                name: "LoaiVanBan");
        }
    }
}
