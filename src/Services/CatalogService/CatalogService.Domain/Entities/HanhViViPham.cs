using CatalogService.Domain.Constants;
using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class HanhViViPham : EntityAuditBase<int>
{
    public int? QuyetDinhXuPhatId { get; set; }

    public int? HoSoXuLyViPhamId { get; set; }

    public int LinhVucXuPhatId { get; set; }

    public int DieuKhoanXuPhatId { get; set; }

    public int? DieuKhoanBoSungId { get; set; }

    public int? DieuKhoanKhacPhucId { get; set; }

    public string? QuyDinh { get; set; }

    public TinhTietViPham TinhTietViPham { get; set; }

    public long MucPhat { get; set; }

    public string? GhiChu { get; set; }

    public virtual DieuKhoanXuPhat DieuKhoanXuPhat { get; set; }

    public virtual DieuKhoanBoSungKhacPhuc DieuKhoanBoSung { get; set; }

    public virtual DieuKhoanBoSungKhacPhuc DieuKhoanKhacPhuc { get; set; }
}