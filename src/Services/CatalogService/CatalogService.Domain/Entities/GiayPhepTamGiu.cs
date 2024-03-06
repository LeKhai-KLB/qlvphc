using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class GiayPhepTamGiu : EntityAuditBase<int>
{
    public int HoSoXuLyViPhamId { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string Ten { get; set; }

    public int SoLuong { get; set; }

    public string TinhTrang { get; set; }

    public string? GhiChu { get; set; }

    public virtual HoSoXuLyViPham HoSoXuLyViPham { get; set; }
}