using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class TangVatPhuongTienTamGiu : EntityAuditBase<int>
{
    public int HoSoXuLyViPhamId { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string Ten { get; set; }

    [Column(TypeName = "nvarchar(50)")]

    public string DonViTinh { get; set; }

    public int SoLuong { get; set; }

    [Column(TypeName = "nvarchar(255)")]

    public string ChungLoai { get; set; }

    [Column(TypeName = "nvarchar(255)")]

    public string TinhTrang { get; set; }

    [Column(TypeName = "nvarchar(512)")]

    public string? GhiChu { get; set; }

    public virtual HoSoXuLyViPham HoSoXuLyViPham { get; set; }
}