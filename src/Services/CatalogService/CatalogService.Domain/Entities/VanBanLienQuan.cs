using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class VanBanLienQuan : EntityAuditBase<int>
{
    public int VanBanPhapLuatId { get; set; }

    public DateTime NgayBanHanh { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string Ten { get; set; }

    public VanBanPhapLuat VanBanPhapLuat { get; set; }
}