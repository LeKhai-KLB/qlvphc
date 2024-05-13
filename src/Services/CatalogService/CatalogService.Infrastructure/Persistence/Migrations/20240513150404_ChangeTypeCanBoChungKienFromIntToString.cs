using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTypeCanBoChungKienFromIntToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CanBoChungKien",
                table: "ChiTietHSXLVPVVBGQ",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CanBoChungKien",
                table: "ChiTietHSXLVPVVBGQ",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
