using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddQuyetDinhXuPhat2 : Migration
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

            migrationBuilder.DropColumn(
                name: "DieuKhoan",
                table: "ChiTietLinhVucXuPhat");

            migrationBuilder.AlterColumn<string>(
                name: "TrichYeuNoiDung",
                table: "VanBanPhapLuat",
                type: "nvarchar(4000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)");

            migrationBuilder.AlterColumn<int>(
                name: "LoaiVanBanId",
                table: "VanBanPhapLuat",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DuongDanUrl",
                table: "VanBanPhapLuat",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<int>(
                name: "CoQuanBanHanhId",
                table: "VanBanPhapLuat",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "HanhVi_QuyetDinh",
                table: "LinhVucXuPhat",
                type: "nvarchar(512)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)");

            migrationBuilder.AlterColumn<string>(
                name: "DanChungNghiDinh",
                table: "LinhVucXuPhat",
                type: "nvarchar(512)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)");

            migrationBuilder.AlterColumn<string>(
                name: "Diem",
                table: "ChiTietLinhVucXuPhat",
                type: "nvarchar(4000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)");

            migrationBuilder.AddColumn<string>(
                name: "Dieu",
                table: "ChiTietLinhVucXuPhat",
                type: "nvarchar(4000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Khoan",
                table: "ChiTietLinhVucXuPhat",
                type: "nvarchar(4000)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ThamQuyenXuPhat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DieuKhoanXuPhatId = table.Column<int>(type: "int", nullable: false),
                    ThamQuyen = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThamQuyenXuPhat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThamQuyenXuPhat_DieuKhoanXuPhat_DieuKhoanXuPhatId",
                        column: x => x.DieuKhoanXuPhatId,
                        principalTable: "DieuKhoanXuPhat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThamQuyenXuPhat_DieuKhoanXuPhatId",
                table: "ThamQuyenXuPhat",
                column: "DieuKhoanXuPhatId");

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

            migrationBuilder.DropTable(
                name: "ThamQuyenXuPhat");

            migrationBuilder.DropColumn(
                name: "Dieu",
                table: "ChiTietLinhVucXuPhat");

            migrationBuilder.DropColumn(
                name: "Khoan",
                table: "ChiTietLinhVucXuPhat");

            migrationBuilder.AlterColumn<string>(
                name: "TrichYeuNoiDung",
                table: "VanBanPhapLuat",
                type: "nvarchar(4000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LoaiVanBanId",
                table: "VanBanPhapLuat",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DuongDanUrl",
                table: "VanBanPhapLuat",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
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

            migrationBuilder.AlterColumn<string>(
                name: "HanhVi_QuyetDinh",
                table: "LinhVucXuPhat",
                type: "nvarchar(512)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DanChungNghiDinh",
                table: "LinhVucXuPhat",
                type: "nvarchar(512)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Diem",
                table: "ChiTietLinhVucXuPhat",
                type: "nvarchar(4000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DieuKhoan",
                table: "ChiTietLinhVucXuPhat",
                type: "nvarchar(4000)",
                nullable: false,
                defaultValue: "");

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
