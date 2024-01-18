using CatalogService.Domain.Constants;

namespace CatalogService.Application.Common.Models.VanBanPhapLuats;

public class CreateVanBanPhapLuatDto
{
    public string SoHieu { get; set; }

    public DateTime NgayBanHanh { get; set; }

    public int CoQuanBanHanhId { get; set; }

    public int LoaiVanBanId { get; set; }

    public string TrichYeuNoiDung { get; set; }

    public TrangThaiVanBan TrangThai { get; set; }

    public DateTime NgayHieuLuc { get; set; }

    public string DuongDanUrl { get; set; }
}