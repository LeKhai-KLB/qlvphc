namespace CatalogService.Application.Common.Models.KetQuaXuPhatTruyCuuHSs;

public class CreateKetQuaXuPhatTruyCuuHSDto
{
    public int HoSoXuLyViPhamId { get; set; }

    public DateTime NgayThiHanh { get; set; }

    public DateTime ThoiHanThiHanh { get; set; }

    public string? NoiDung { get; set; }

    public int CoQuanBanHanhId { get; set; }
}