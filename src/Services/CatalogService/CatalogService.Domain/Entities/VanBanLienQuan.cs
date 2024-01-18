using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class VanBanLienQuan : EntityAuditBase<int>
{
    public int VanBanPhapLuatId { get; set; }

    public DateTime NgayBanHanh { get; set; }

    public string Ten { get; set; }

    public VanBanPhapLuat VanBanPhapLuat { get; set; }
}