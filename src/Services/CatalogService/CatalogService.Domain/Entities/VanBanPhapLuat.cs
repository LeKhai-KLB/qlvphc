using CatalogService.Domain.Constants;
using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class VanBanPhapLuat : EntityAuditBase<int>
{
    public string SoHieu { get; set; }

    public DateTime NgayBanHanh { get; set; }

    public int CoQuanBanHanhId { get; set; }

    public int LoaiVanBanId { get; set; }

    public string TrichYeuNoiDung { get; set; }

    public TrangThaiVanBan TrangThai { get; set; }

    public DateTime NgayHieuLuc { get; set; }

    public string DuongDanUrl { get; set; }

    public LoaiVanBan LoaiVanBan { get; set; }

    public CoQuanBanHanh CoQuanBanHanh { get; set; }

    public List<VanBanLienQuan> VanBanLienQuan { get; set; }
}