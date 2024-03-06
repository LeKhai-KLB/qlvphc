using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class HoSoXuLyViPham : EntityAuditBase<int>
{
    [Column(TypeName = "nvarchar(255)")]
    public string MaHoSo { get; set; }

    public DateTime NgayHoSo { get; set; }

    [Column(TypeName = "nvarchar(512)")]
    public string TenHoSo { get; set; }

    public int TrangThai { get; set; }

    [Column(TypeName = "nvarchar(512)")]
    public string HanhViViPham { get; set; }

    public virtual List<LinhVucXuPhat> LinhVucXuPhats { get; set; }
    public virtual List<TangVatPhuongTienTamGiu> TangVatPhuongTienTamGius { get; set; }
    // TODO GiayPhepTamGiu
    //public virtual List<LinhVucXuPhat> LinhVucXuPhats { get; set; }
}