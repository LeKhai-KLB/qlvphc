using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoQuanBanHanh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhomCoQuan = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    TenCoQuan = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoQuanBanHanh", x => x.Id);
                });

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
                name: "LoaiVanBan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiVanBan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TinhThanhPho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    MaDinhDanh = table.Column<string>(type: "varchar(50)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhThanhPho", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VanBanGiaiQuyet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaGiayTo = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    TheoNghiDinh = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    TenGiayTo = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VanBanGiaiQuyet", x => x.Id);
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
                name: "LinhVucXuPhat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLinhVuc = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    NhomLinhVuc = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    NghiDinh = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    HanhVi_QuyetDinh = table.Column<string>(type: "nvarchar(512)", nullable: true),
                    DanChungNghiDinh = table.Column<string>(type: "nvarchar(512)", nullable: true),
                    HienThi = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    HetHieuLuc = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    HoSoXuLyViPhamId = table.Column<int>(type: "int", nullable: true),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhVucXuPhat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinhVucXuPhat_HoSoXuLyViPham_HoSoXuLyViPhamId",
                        column: x => x.HoSoXuLyViPhamId,
                        principalTable: "HoSoXuLyViPham",
                        principalColumn: "Id");
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
                name: "VanBanPhapLuat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoHieu = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    NgayBanHanh = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    CoQuanBanHanhId = table.Column<int>(type: "int", nullable: true),
                    LoaiVanBanId = table.Column<int>(type: "int", nullable: true),
                    TrichYeuNoiDung = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    NgayHieuLuc = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    DuongDanUrl = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VanBanPhapLuat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VanBanPhapLuat_CoQuanBanHanh_CoQuanBanHanhId",
                        column: x => x.CoQuanBanHanhId,
                        principalTable: "CoQuanBanHanh",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VanBanPhapLuat_LoaiVanBan_LoaiVanBanId",
                        column: x => x.LoaiVanBanId,
                        principalTable: "LoaiVanBan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuanHuyen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaDinhDanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    TinhThanhPhoId = table.Column<int>(type: "int", nullable: false),
                    DanhMucDinhDanhId = table.Column<int>(type: "int", nullable: true),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanHuyen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuanHuyen_DanhMucDinhDanh_DanhMucDinhDanhId",
                        column: x => x.DanhMucDinhDanhId,
                        principalTable: "DanhMucDinhDanh",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuanHuyen_TinhThanhPho_TinhThanhPhoId",
                        column: x => x.TinhThanhPhoId,
                        principalTable: "TinhThanhPho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietLinhVucXuPhat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinhVucXuPhatId = table.Column<int>(type: "int", nullable: false),
                    Dieu = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    Khoan = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    Diem = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietLinhVucXuPhat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietLinhVucXuPhat_LinhVucXuPhat_LinhVucXuPhatId",
                        column: x => x.LinhVucXuPhatId,
                        principalTable: "LinhVucXuPhat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "VanBanLienQuan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VanBanPhapLuatId = table.Column<int>(type: "int", nullable: false),
                    NgayBanHanh = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    Ten = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VanBanLienQuan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VanBanLienQuan_VanBanPhapLuat_VanBanPhapLuatId",
                        column: x => x.VanBanPhapLuatId,
                        principalTable: "VanBanPhapLuat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XaPhuong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaDinhDanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    QuanHuyenId = table.Column<int>(type: "int", nullable: false),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    NguoiCapNhatCuoi = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XaPhuong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XaPhuong_QuanHuyen_QuanHuyenId",
                        column: x => x.QuanHuyenId,
                        principalTable: "QuanHuyen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_ChiTietLinhVucXuPhat_LinhVucXuPhatId",
                table: "ChiTietLinhVucXuPhat",
                column: "LinhVucXuPhatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietQuyetDinhXuPhat_QuyetDinhXuPhatId",
                table: "ChiTietQuyetDinhXuPhat",
                column: "QuyetDinhXuPhatId");

            migrationBuilder.CreateIndex(
                name: "IX_DieuKhoanXuPhat_LinhVucXuPhatId",
                table: "DieuKhoanXuPhat",
                column: "LinhVucXuPhatId");

            migrationBuilder.CreateIndex(
                name: "IX_GiayPhepTamGiu_HoSoXuLyViPhamId",
                table: "GiayPhepTamGiu",
                column: "HoSoXuLyViPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_LinhVucXuPhat_HoSoXuLyViPhamId",
                table: "LinhVucXuPhat",
                column: "HoSoXuLyViPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_QuanHuyen_DanhMucDinhDanhId",
                table: "QuanHuyen",
                column: "DanhMucDinhDanhId");

            migrationBuilder.CreateIndex(
                name: "IX_QuanHuyen_TinhThanhPhoId",
                table: "QuanHuyen",
                column: "TinhThanhPhoId");

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

            migrationBuilder.CreateIndex(
                name: "IX_ThamQuyenXuPhat_DieuKhoanXuPhatId",
                table: "ThamQuyenXuPhat",
                column: "DieuKhoanXuPhatId");

            migrationBuilder.CreateIndex(
                name: "IX_VanBanLienQuan_VanBanPhapLuatId",
                table: "VanBanLienQuan",
                column: "VanBanPhapLuatId");

            migrationBuilder.CreateIndex(
                name: "IX_VanBanPhapLuat_CoQuanBanHanhId",
                table: "VanBanPhapLuat",
                column: "CoQuanBanHanhId");

            migrationBuilder.CreateIndex(
                name: "IX_VanBanPhapLuat_LoaiVanBanId",
                table: "VanBanPhapLuat",
                column: "LoaiVanBanId");

            migrationBuilder.CreateIndex(
                name: "IX_XaPhuong_QuanHuyenId",
                table: "XaPhuong",
                column: "QuanHuyenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietLinhVucXuPhat");

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
                name: "ThamQuyenXuPhat");

            migrationBuilder.DropTable(
                name: "VanBanGiaiQuyet");

            migrationBuilder.DropTable(
                name: "VanBanLienQuan");

            migrationBuilder.DropTable(
                name: "XaPhuong");

            migrationBuilder.DropTable(
                name: "QuyetDinhXuPhat");

            migrationBuilder.DropTable(
                name: "DieuKhoanXuPhat");

            migrationBuilder.DropTable(
                name: "VanBanPhapLuat");

            migrationBuilder.DropTable(
                name: "QuanHuyen");

            migrationBuilder.DropTable(
                name: "LinhVucXuPhat");

            migrationBuilder.DropTable(
                name: "CoQuanBanHanh");

            migrationBuilder.DropTable(
                name: "LoaiVanBan");

            migrationBuilder.DropTable(
                name: "DanhMucDinhDanh");

            migrationBuilder.DropTable(
                name: "TinhThanhPho");

            migrationBuilder.DropTable(
                name: "HoSoXuLyViPham");
        }
    }
}
