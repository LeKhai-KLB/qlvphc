using CatalogService.Domain.Constants;
using Contracts.Domains;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogService.Domain.Entities;

public class DieuKhoanBoSungKhacPhuc : EntityAuditBase<int>
{
    public int DieuKhoanXuPhatId { get; set; }

    [Column(TypeName = "nvarchar(512)")]
    public string Dieu { get; set; }

    [Column(TypeName = "nvarchar(512)")]
    public string Khoan { get; set; }

    [Column(TypeName = "nvarchar(512)")]
    public string Diem { get; set; }

    public LoaiDieuKhoan LoaiDieuKhoan { get; set; }

    public bool IsDeleted { get; set; }

    public virtual DieuKhoanXuPhat DieuKhoanXuPhat { get; set; }

    public List<HanhViViPham> HVVPDieuKhoanBoSung {  get; set; }

    public List<HanhViViPham> HVVPDieuKhoanKhacPhuc { get; set; }
}