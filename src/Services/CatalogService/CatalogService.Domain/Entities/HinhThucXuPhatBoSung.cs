using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class HinhThucXuPhatBoSung : EntityAuditBase<int>
{
    [Column(TypeName = "nvarchar(255)")]
    public string Ten { get; set; }

    public bool IsDeleted { get; set; }
}