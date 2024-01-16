using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Domains;

namespace CatalogService.Domain.Entities
{
    public class TinhThanhPho : EntityAuditBase<int>
    {
        [Column(TypeName = "nvarchar(255)")]
        public string Ten { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string MaDinhDanh { get; set; }

        public bool IsDeleted { get; set; }

        public List<QuanHuyen> QuanHuyen { get; set; }
    }
}