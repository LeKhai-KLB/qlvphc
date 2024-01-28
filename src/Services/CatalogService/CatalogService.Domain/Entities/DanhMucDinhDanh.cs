using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Domains;

namespace CatalogService.Domain.Entities
{
    public class DanhMucDinhDanh : EntityAuditBase<int>
    {
        [Column(TypeName = "varchar(50)")]
        public string MaDinhDanh { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Ten { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string DiaChi { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Email { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? DienThoai { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? Website { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? MaDinhDanhTCVN { get; set; }

        public bool IsDeleted { get; set; }

        public List<QuanHuyen> QuanHuyen { get; set; }
    }
}