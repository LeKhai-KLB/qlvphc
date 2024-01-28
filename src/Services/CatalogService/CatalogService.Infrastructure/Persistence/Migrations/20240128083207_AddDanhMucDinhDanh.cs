using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDanhMucDinhDanh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DanhMucDinhDanhId",
                table: "QuanHuyen",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DanhMucDinhDanh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDinhDanh = table.Column<string>(type: "varchar(50)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DienThoai = table.Column<string>(type: "varchar(50)", nullable: true),
                    Website = table.Column<string>(type: "varchar(255)", nullable: true),
                    MaDinhDanhTCVN = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucDinhDanh", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuanHuyen_DanhMucDinhDanhId",
                table: "QuanHuyen",
                column: "DanhMucDinhDanhId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuanHuyen_DanhMucDinhDanh_DanhMucDinhDanhId",
                table: "QuanHuyen",
                column: "DanhMucDinhDanhId",
                principalTable: "DanhMucDinhDanh",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuanHuyen_DanhMucDinhDanh_DanhMucDinhDanhId",
                table: "QuanHuyen");

            migrationBuilder.DropTable(
                name: "DanhMucDinhDanh");

            migrationBuilder.DropIndex(
                name: "IX_QuanHuyen_DanhMucDinhDanhId",
                table: "QuanHuyen");

            migrationBuilder.DropColumn(
                name: "DanhMucDinhDanhId",
                table: "QuanHuyen");
        }
    }
}
