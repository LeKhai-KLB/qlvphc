using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class LinhVucXuPhat : EntityAuditBase<int>
{
    [Column(TypeName = "nvarchar(255)")]
    public string TenLinhVuc { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string NhomLinhVuc { get; set; }

    [Column(TypeName = "nvarchar(512)")]
    public string NghiDinh { get; set; }

    [Column(TypeName = "nvarchar(512)")]
    public string HanhVi_QuyetDinh { get; set; }

    [Column(TypeName = "nvarchar(512)")]
    public string DanChungNghiDinh { get; set; }

    public bool HienThi { get; set; }

    public bool HetHieuLuc { get; set; }

    public List<ChiTietLinhVucXuPhat> ChiTietLinhVucXuPhat { get; set; }
}