using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddQuyetDinhXuPhat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HoSoXuLyViPhamId",
                table: "LinhVucXuPhat",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HinhThucXuPhatBoSung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhThucXuPhatBoSung", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HinhThucXuPhatChinh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhThucXuPhatChinh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoSoXuLyViPham",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHoSo = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    NgayHoSo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenHoSo = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    HanhViViPham = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoXuLyViPham", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GiayPhepTamGiu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoSoXuLyViPhamId = table.Column<int>(type: "int", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiayPhepTamGiu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiayPhepTamGiu_HoSoXuLyViPham_HoSoXuLyViPhamId",
                        column: x => x.HoSoXuLyViPhamId,
                        principalTable: "HoSoXuLyViPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuyetDinhXuPhat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoSoXuLyViPhamId = table.Column<int>(type: "int", nullable: false),
                    NgayNhapQuyetDinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoQuyetDinh = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    NgayQuyetDinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HieuLucThiHanhNgay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoQuanBanHanhId = table.Column<int>(type: "int", nullable: false),
                    NguoiRaQuyetDinhId = table.Column<int>(type: "int", nullable: false),
                    LoaiDoiTuongViPham = table.Column<int>(type: "int", nullable: false),
                    DoiTuongViPhamId = table.Column<int>(type: "int", nullable: false),
                    DoiTuongViPhamKhac = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CanCuVanBan = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    CanCuQuyDinh = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    SoTienPhat = table.Column<long>(type: "bigint", nullable: true),
                    SoTienPhatBangChu = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    TienKhacPhuc = table.Column<long>(type: "bigint", nullable: true),
                    NoiThucHien = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    TienTruyThu = table.Column<long>(type: "bigint", nullable: true),
                    ThoiHanKhacPhucHauQua = table.Column<int>(type: "int", nullable: true),
                    ThoiHanThucHienXuPhatBoSung = table.Column<int>(type: "int", nullable: true),
                    NoiNopTienPhat = table.Column<int>(type: "int", nullable: false),
                    NoiNopTienPhatTuNhap = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DiaDiemViPham = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    HinhThucXuPhatChinh = table.Column<int>(type: "int", nullable: false),
                    TinhTietTangNang = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    TinhTietGiamNhe = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    HinhThucXuPhatCuThe = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    HinhThucXuPhatBoSung = table.Column<int>(type: "int", nullable: true),
                    HinhThucXuPhatBoSungCuThe = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    BienPhapKhacPhucHauQua = table.Column<int>(type: "int", nullable: false),
                    BienPhapKhacPhucHauQuaCuThe = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    NoiDungLienQuanKhacPhucHauQua = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DonViPhoiHopThucHien = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    NoiNhan = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyetDinhXuPhat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuyetDinhXuPhat_CoQuanBanHanh_CoQuanBanHanhId",
                        column: x => x.CoQuanBanHanhId,
                        principalTable: "CoQuanBanHanh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuyetDinhXuPhat_HoSoXuLyViPham_HoSoXuLyViPhamId",
                        column: x => x.HoSoXuLyViPhamId,
                        principalTable: "HoSoXuLyViPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TangVatPhuongTienTamGiu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoSoXuLyViPhamId = table.Column<int>(type: "int", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    ChungLoai = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(512)", nullable: true),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TangVatPhuongTienTamGiu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TangVatPhuongTienTamGiu_HoSoXuLyViPham_HoSoXuLyViPhamId",
                        column: x => x.HoSoXuLyViPhamId,
                        principalTable: "HoSoXuLyViPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietQuyetDinhXuPhat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuyetDinhXuPhatId = table.Column<int>(type: "int", nullable: false),
                    LinhVucXuPhatId = table.Column<int>(type: "int", nullable: false),
                    DieuThiHanhId = table.Column<int>(type: "int", nullable: false),
                    KhoanDiemThiHanhId = table.Column<int>(type: "int", nullable: false),
                    DieuKhoanDiemBoSungId = table.Column<int>(type: "int", nullable: false),
                    DieuKhoanKhacPhucId = table.Column<int>(type: "int", nullable: false),
                    QuyDinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhTietId = table.Column<int>(type: "int", nullable: false),
                    MucPhat = table.Column<long>(type: "bigint", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietQuyetDinhXuPhat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietQuyetDinhXuPhat_QuyetDinhXuPhat_QuyetDinhXuPhatId",
                        column: x => x.QuyetDinhXuPhatId,
                        principalTable: "QuyetDinhXuPhat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinhVucXuPhat_HoSoXuLyViPhamId",
                table: "LinhVucXuPhat",
                column: "HoSoXuLyViPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietQuyetDinhXuPhat_QuyetDinhXuPhatId",
                table: "ChiTietQuyetDinhXuPhat",
                column: "QuyetDinhXuPhatId");

            migrationBuilder.CreateIndex(
                name: "IX_GiayPhepTamGiu_HoSoXuLyViPhamId",
                table: "GiayPhepTamGiu",
                column: "HoSoXuLyViPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyetDinhXuPhat_CoQuanBanHanhId",
                table: "QuyetDinhXuPhat",
                column: "CoQuanBanHanhId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyetDinhXuPhat_HoSoXuLyViPhamId",
                table: "QuyetDinhXuPhat",
                column: "HoSoXuLyViPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_TangVatPhuongTienTamGiu_HoSoXuLyViPhamId",
                table: "TangVatPhuongTienTamGiu",
                column: "HoSoXuLyViPhamId");

            migrationBuilder.AddForeignKey(
                name: "FK_LinhVucXuPhat_HoSoXuLyViPham_HoSoXuLyViPhamId",
                table: "LinhVucXuPhat",
                column: "HoSoXuLyViPhamId",
                principalTable: "HoSoXuLyViPham",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinhVucXuPhat_HoSoXuLyViPham_HoSoXuLyViPhamId",
                table: "LinhVucXuPhat");

            migrationBuilder.DropTable(
                name: "ChiTietQuyetDinhXuPhat");

            migrationBuilder.DropTable(
                name: "GiayPhepTamGiu");

            migrationBuilder.DropTable(
                name: "HinhThucXuPhatBoSung");

            migrationBuilder.DropTable(
                name: "HinhThucXuPhatChinh");

            migrationBuilder.DropTable(
                name: "TangVatPhuongTienTamGiu");

            migrationBuilder.DropTable(
                name: "QuyetDinhXuPhat");

            migrationBuilder.DropTable(
                name: "HoSoXuLyViPham");

            migrationBuilder.DropIndex(
                name: "IX_LinhVucXuPhat_HoSoXuLyViPhamId",
                table: "LinhVucXuPhat");

            migrationBuilder.DropColumn(
                name: "HoSoXuLyViPhamId",
                table: "LinhVucXuPhat");
        }
    }
}
