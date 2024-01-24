using System.ComponentModel.DataAnnotations.Schema;
using CatalogService.Domain.Constants;
using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class VanBanPhapLuat : EntityAuditBase<int>
{
    [Column(TypeName = "nvarchar(255)")]
    public string SoHieu { get; set; }

    public DateTime NgayBanHanh { get; set; }

    public int CoQuanBanHanhId { get; set; }

    public int LoaiVanBanId { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string TrichYeuNoiDung { get; set; }

    public TrangThaiVanBan TrangThai { get; set; }

    public DateTime NgayHieuLuc { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string DuongDanUrl { get; set; }

    public LoaiVanBan LoaiVanBan { get; set; }

    public CoQuanBanHanh CoQuanBanHanh { get; set; }

    public List<VanBanLienQuan> VanBanLienQuan { get; set; }
}