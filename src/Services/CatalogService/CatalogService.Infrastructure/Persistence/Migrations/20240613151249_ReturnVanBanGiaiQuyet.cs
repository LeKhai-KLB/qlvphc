using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ReturnVanBanGiaiQuyet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HSXLVP_VanBanGiaiQuyets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "HSXLVP_VanBanGiaiQuyets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "HSXLVP_VanBanGiaiQuyets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NguoiCapNhatCuoi",
                table: "HSXLVP_VanBanGiaiQuyets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NguoiTao",
                table: "HSXLVP_VanBanGiaiQuyets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "HSXLVP_VanBanGiaiQuyets");

            migrationBuilder.DropColumn(
                name: "NgayCapNhatCuoi",
                table: "HSXLVP_VanBanGiaiQuyets");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "HSXLVP_VanBanGiaiQuyets");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhatCuoi",
                table: "HSXLVP_VanBanGiaiQuyets");

            migrationBuilder.DropColumn(
                name: "NguoiTao",
                table: "HSXLVP_VanBanGiaiQuyets");
        }
    }
}
