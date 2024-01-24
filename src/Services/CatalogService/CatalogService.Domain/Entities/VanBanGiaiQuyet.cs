using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class VanBanGiaiQuyet : EntityAuditBase<int>
{
    [Column(TypeName = "nvarchar(255)")]
    public string MaGiayTo { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string TheoNghiDinh { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string TenGiayTo { get; set; }
}