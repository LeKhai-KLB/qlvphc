using CatalogService.Domain.Constants;

namespace CatalogService.Application.Common.Models.HoSoXuLyViPhams;

public class CreateHoSoXuLyViPhamDto
{
    public string SoHoSo { get; set; }

    public DateTime NgayHoSo { get; set; }

    public string TenHoSo { get; set; }

    public int? CaNhanViPhamId { get; set; }

    public bool IsCaNhanViPhamKhac { get; set; }

    public string? ThongTinKhac { get; set; }

    public List<string>? HinhAnhViPhams { get; set; }

    public TrangThaiHoSoViPham TrangThaiHoSoViPham { get; set; }

    public TinhTietViPham TinhTietViPham { get; set; }

    public LoaiVuViecViPham LoaiVuViecViPham { get; set; }

    public int[]? VanBanGiaiQuyetIds { get; set; }
}