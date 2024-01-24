using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class LoaiVanBan : EntityAuditBase<int>
{
    [Column(TypeName = "nvarchar(255)")]
    public string Ten { get; set; }

    public List<VanBanPhapLuat> VanBanPhapLuat { get; set; }
}