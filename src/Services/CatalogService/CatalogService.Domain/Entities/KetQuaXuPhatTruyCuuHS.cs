using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class KetQuaXuPhatTruyCuuHS : EntityAuditBase<int>
{
    public int HoSoXuLyViPhamId { get; set; }

    public DateTime NgayThiHanh { get; set; }

    public DateTime ThoiHanThiHanh { get; set; }

    public string? NoiDung { get; set; }

    public int CoQuanBanHanhId { get; set; }
}