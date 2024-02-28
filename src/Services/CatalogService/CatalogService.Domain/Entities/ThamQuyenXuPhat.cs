using Contracts.Domains;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogService.Domain.Entities;

public class ThamQuyenXuPhat : EntityAuditBase<int>
{
    public int DieuKhoanXuPhatId { get; set; }

    [Column(TypeName = "nvarchar(512)")]
    public string ThamQuyen { get; set; }

    public bool IsDeleted { get; set; }

    public virtual DieuKhoanXuPhat DieuKhoanXuPhat { get; set; }
}