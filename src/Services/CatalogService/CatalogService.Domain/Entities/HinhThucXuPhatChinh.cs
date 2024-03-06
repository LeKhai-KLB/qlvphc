using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class HinhThucXuPhatChinh : EntityAuditBase<int>
{
    [Column(TypeName = "nvarchar(255)")]
    public string Ten { get; set; }

    public bool IsDeleted { get; set; }
}