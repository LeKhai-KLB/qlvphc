using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class alterVBPL_FKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VanBanPhapLuat_CoQuanBanHanh_CoQuanBanHanhId",
                table: "VanBanPhapLuat");

            migrationBuilder.DropForeignKey(
                name: "FK_VanBanPhapLuat_LoaiVanBan_LoaiVanBanId",
                table: "VanBanPhapLuat");

            migrationBuilder.AlterColumn<int>(
                name: "LoaiVanBanId",
                table: "VanBanPhapLuat",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CoQuanBanHanhId",
                table: "VanBanPhapLuat",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_VanBanPhapLuat_CoQuanBanHanh_CoQuanBanHanhId",
                table: "VanBanPhapLuat",
                column: "CoQuanBanHanhId",
                principalTable: "CoQuanBanHanh",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VanBanPhapLuat_LoaiVanBan_LoaiVanBanId",
                table: "VanBanPhapLuat",
                column: "LoaiVanBanId",
                principalTable: "LoaiVanBan",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VanBanPhapLuat_CoQuanBanHanh_CoQuanBanHanhId",
                table: "VanBanPhapLuat");

            migrationBuilder.DropForeignKey(
                name: "FK_VanBanPhapLuat_LoaiVanBan_LoaiVanBanId",
                table: "VanBanPhapLuat");

            migrationBuilder.AlterColumn<int>(
                name: "LoaiVanBanId",
                table: "VanBanPhapLuat",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CoQuanBanHanhId",
                table: "VanBanPhapLuat",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VanBanPhapLuat_CoQuanBanHanh_CoQuanBanHanhId",
                table: "VanBanPhapLuat",
                column: "CoQuanBanHanhId",
                principalTable: "CoQuanBanHanh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VanBanPhapLuat_LoaiVanBan_LoaiVanBanId",
                table: "VanBanPhapLuat",
                column: "LoaiVanBanId",
                principalTable: "LoaiVanBan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
