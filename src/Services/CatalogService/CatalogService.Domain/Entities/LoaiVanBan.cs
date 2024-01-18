using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class LoaiVanBan : EntityAuditBase<int>
{
    public string Ten { get; set; }

    public List<VanBanPhapLuat> VanBanPhapLuat { get; set; }
}