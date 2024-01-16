using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class ChiTietLinhVucXuPhat : EntityAuditBase<int>
{
    public int LinhVucXuPhatId { get; set; }

    public string DieuKhoan { get; set; }

    public string Diem { get; set; }

    public LinhVucXuPhat LinhVucXuPhat { get; set; }
}