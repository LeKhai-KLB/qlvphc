using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddVanBanGiaiQuyetToChiTietHSXLVPVVBGQ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VanBanGiaiQuyetId",
                table: "ChiTietHSXLVPVVBGQ",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VanBanGiaiQuyetId",
                table: "ChiTietHSXLVPVVBGQ");
        }
    }
}
