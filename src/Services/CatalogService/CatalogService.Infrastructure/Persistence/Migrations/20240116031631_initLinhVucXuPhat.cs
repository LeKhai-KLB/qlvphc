using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initLinhVucXuPhat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LinhVucXuPhat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLinhVuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhomLinhVuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NghiDinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HanhVi_QuyetDinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DanChungNghiDinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HienThi = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    HetHieuLuc = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhVucXuPhat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietLinhVucXuPhat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinhVucXuPhatId = table.Column<int>(type: "int", nullable: false),
                    DieuKhoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietLinhVucXuPhat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietLinhVucXuPhat_LinhVucXuPhat_LinhVucXuPhatId",
                        column: x => x.LinhVucXuPhatId,
                        principalTable: "LinhVucXuPhat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietLinhVucXuPhat_LinhVucXuPhatId",
                table: "ChiTietLinhVucXuPhat",
                column: "LinhVucXuPhatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietLinhVucXuPhat");

            migrationBuilder.DropTable(
                name: "LinhVucXuPhat");
        }
    }
}
