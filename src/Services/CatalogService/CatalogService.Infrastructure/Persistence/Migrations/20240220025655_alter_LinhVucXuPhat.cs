using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class alter_LinhVucXuPhat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DieuKhoan",
                table: "ChiTietLinhVucXuPhat");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dieu",
                table: "ChiTietLinhVucXuPhat");

            migrationBuilder.DropColumn(
                name: "Khoan",
                table: "ChiTietLinhVucXuPhat");

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
        }
    }
}
