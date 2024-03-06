using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class ChiTietQuyetDinhXuPhat : EntityAuditBase<int>
{
    public int QuyetDinhXuPhatId { get; set; }
    public int LinhVucXuPhatId { get; set; }

    public int DieuThiHanhId { get; set; }

    public int KhoanDiemThiHanhId { get; set; }

    public int DieuKhoanDiemBoSungId { get; set; }

    public int DieuKhoanKhacPhucId { get; set; }

    public string QuyDinh { get; set; }

    public int TinhTietId { get; set; }

    public long MucPhat { get; set; }

    public string? GhiChu { get; set; }

    public virtual QuyetDinhXuPhat QuyetDinhXuPhat { get; set; }

}