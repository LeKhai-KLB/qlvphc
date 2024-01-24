using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class alterVanBanGiaiQuyet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrichYeuNoiDung",
                table: "VanBanGiaiQuyet",
                newName: "TheoNghiDinh");

            migrationBuilder.RenameColumn(
                name: "DuongDanUrl",
                table: "VanBanGiaiQuyet",
                newName: "TenGiayTo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TheoNghiDinh",
                table: "VanBanGiaiQuyet",
                newName: "TrichYeuNoiDung");

            migrationBuilder.RenameColumn(
                name: "TenGiayTo",
                table: "VanBanGiaiQuyet",
                newName: "DuongDanUrl");
        }
    }
}
