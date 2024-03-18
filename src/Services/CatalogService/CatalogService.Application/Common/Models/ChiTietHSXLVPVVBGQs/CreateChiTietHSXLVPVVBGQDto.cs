using CatalogService.Domain.Constants;

namespace CatalogService.Application.Common.Models.ChiTietHSXLVPVVBGQs;

public class CreateChiTietHSXLVPVVBGQDto
{
    public DateTime NgayNhap { get; set; }

    public DateTime? ThoiDiemLapBB { get; set; }

    public DateTime? ThoiDiemKetThucBB { get; set; }

    public string SoBB { get; set; }

    public string? CanCuLapBB { get; set; }

    public string? DiaDiemLapBB { get; set; }

    public string? LyDoLapBB { get; set; }

    public int NguoiLapBB { get; set; }

    public int? NguoiChungKien1Id { get; set; }

    public int? NguoiChungKien2Id { get; set; }

    public int? NguoiPhienDichId { get; set; }

    public int? CanBoChungKien { get; set; }

    public bool IsCaNhan { get; set; }

    public int DoiTuongViPhamId { get; set; }

    public LoaiVanBanHSXLVPVBGQ LoaiVanBanHSXLVPVBGQ { get; set; }

    public int? NguoiGiamHoId { get; set; }

    public int? NguoiCoThamQuyenGQId { get; set; }

    public string? CNTCBiThietHai { get; set; }

    public string? YKienCNTCViPham { get; set; }

    public string? YKienNguoiChungKien { get; set; }

    public string? YKienNoiThietHai { get; set; }

    public string? BienPhapNganChan { get; set; }

    public string? GhiChu { get; set; }

    public DateTime? NgayThangHen { get; set; }

    public string? DiaDiemHen { get; set; }

    public int? ThoiHanGiaiTrinh { get; set; }

    public int? SoToBB { get; set; }

    public int? BBLapThanh { get; set; }

    public string? LyDoKhongKyBB { get; set; }

    public string? LyDoNCKKhongKyBB { get; set; }

    public string? YKienDaiDienChinhQuyen { get; set; }
}