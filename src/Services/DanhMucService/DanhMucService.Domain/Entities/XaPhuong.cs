using Contracts.Domains;

namespace DanhMucService.Domain.Entities
{
    public class XaPhuong : EntityAuditBase<int>
    {
        public string Ten { get; set; }
        public string MaDinhDanh { get; set; }

        public bool IsDeleted { get; set; }

        public int QuanHuyenId { get; set; }
        public QuanHuyen QuanHuyen { get; set; }
    }
}