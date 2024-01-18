using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class CoQuanBanHanh : EntityAuditBase<int>
{
    public string NhomCoQuan { get; set; }

    public string TenCoQuan { get; set; }

    public List<VanBanPhapLuat> VanBanPhapLuat { get; set; }
}