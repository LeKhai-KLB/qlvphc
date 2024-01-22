using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Domains;

namespace CatalogService.Domain.Entities
{
    public class DieuKhoanXuPhat : EntityAuditBase<int>
    {
        public int LinhVucXuPhatId { get; set; }

        [Column(TypeName = "nvarchar(512)")]
        public string Dieu { get; set; }
        [Column(TypeName = "nvarchar(512)")]
        public string Khoan { get; set; }
        [Column(TypeName = "nvarchar(512)")]
        public string Diem { get; set; }
        public bool IsDeleted { get; set; }

        public virtual LinhVucXuPhat LinhVucXuPhat { get; set; }
    }
}