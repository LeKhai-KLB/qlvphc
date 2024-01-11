using Contracts.Domains;

namespace DanhMucService.Domain.Entities
{
    public class QuanHuyen : EntityAuditBase<int>
    {
        public string Ten { get; set; }

        public string MaDinhDanh { get; set; }

        public bool IsDeleted { get; set; }

        public int TinhThanhPhoId { get; set; }
        public TinhThanhPho TinhThanhPho { get; set; }

        public List<XaPhuong> XaPhuong { get; set; }
    }
}