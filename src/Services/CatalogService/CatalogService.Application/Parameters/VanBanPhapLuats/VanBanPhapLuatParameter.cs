using CatalogService.Domain.Constants;
using Shared.SeedWord;

namespace CatalogService.Application.Parameters.VanBanPhapLuats;

public class VanBanPhapLuatParameter : RequestParameters
{
    public string? SoHieu { get; set; }

    public int? CoQuanBanHanhId { get; set; }

    public int? LoaiVanBanId { get; set; }

    public DateTime? NgayBanHanhTu { get; set; }

    public DateTime? NgayBanHanhDen { get; set; }

    public TrangThaiVanBan? TrangThai { get; set; }
}