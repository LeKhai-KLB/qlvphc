using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDieuKhoanXuPhat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayHieuLuc",
                table: "VanBanPhapLuat",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayBanHanh",
                table: "VanBanPhapLuat",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayBanHanh",
                table: "VanBanLienQuan",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "DieuKhoanXuPhat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinhVucXuPhatId = table.Column<int>(type: "int", nullable: false),
                    Dieu = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    Khoan = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    Diem = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DieuKhoanXuPhat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DieuKhoanXuPhat_LinhVucXuPhat_LinhVucXuPhatId",
                        column: x => x.LinhVucXuPhatId,
                        principalTable: "LinhVucXuPhat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DieuKhoanXuPhat_LinhVucXuPhatId",
                table: "DieuKhoanXuPhat",
                column: "LinhVucXuPhatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DieuKhoanXuPhat");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayHieuLuc",
                table: "VanBanPhapLuat",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayBanHanh",
                table: "VanBanPhapLuat",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayBanHanh",
                table: "VanBanLienQuan",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
