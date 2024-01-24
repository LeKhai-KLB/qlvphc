using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class CoQuanBanHanh : EntityAuditBase<int>
{
    [Column(TypeName = "nvarchar(255)")]
    public string NhomCoQuan { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string TenCoQuan { get; set; }

    public List<VanBanPhapLuat> VanBanPhapLuat { get; set; }
}