﻿using CatalogService.Domain.Constants;

namespace CatalogService.Application.Common.Models.QuyetDinhXuPhats;

public class CreateQuyetDinhXuPhatDto
{
    public int HoSoXuLyViPhamId { get; set; }
    public LoaiHinhThucXuPhat LoaiHinhThucXuPhat { get; set; }
    public DateTime NgayNhapQuyetDinh { get; set; }

    public string SoQuyetDinh { get; set; }

    public DateTime NgayQuyetDinh { get; set; }

    public DateTime HieuLucThiHanhNgay { get; set; }

    public int CoQuanBanHanhId { get; set; }

    public Guid NguoiRaQuyetDinhId { get; set; }

    public int LoaiDoiTuongViPham { get; set; }

    public int DoiTuongViPhamId { get; set; }

    public string? DoiTuongViPhamKhac { get; set; }

    public string CanCuVanBan { get; set; }

    public string CanCuQuyDinh { get; set; }
    public long? SoTienPhat { get; set; }

    public string? SoTienPhatBangChu { get; set; }
    public long? TienKhacPhuc { get; set; }

    public string? NoiThucHien { get; set; }
    public long? TienTruyThu { get; set; }
    public int? ThoiHanKhacPhucHauQua { get; set; }
    public int? ThoiHanThucHienXuPhatBoSung { get; set; }

    public int NoiNopTienPhat { get; set; }

    public string? NoiNopTienPhatTuNhap { get; set; }

    public string DiaDiemViPham { get; set; }

    public int HinhThucXuPhatChinh { get; set; }

    public string? TinhTietTangNang { get; set; }

    public string? TinhTietGiamNhe { get; set; }

    public string HinhThucXuPhatCuThe { get; set; }

    public string? HinhThucXuPhatBoSungEnums { get; set; }

    public string? HinhThucXuPhatBoSungCuThe { get; set; }

    public string? BienPhapKhacPhucHauQuaEnums { get; set; }

    public string? BienPhapKhacPhucHauQuaCuThe { get; set; }

    public string? NoiDungLienQuanKhacPhucHauQua { get; set; }

    public string DonViPhoiHopThucHien { get; set; }

    public string NoiNhan { get; set; }
}