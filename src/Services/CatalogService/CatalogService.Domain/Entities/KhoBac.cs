using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class KhoBac : EntityAuditBase<int>
{
    public string TenKhoBac { get; set; }

    public string? TaiKhoan { get; set; }

    public string? DiaChi { get; set; }

    public string? DiaDiemGiaoDich { get; set; }

    public string? TenCoQuan { get; set; }
}