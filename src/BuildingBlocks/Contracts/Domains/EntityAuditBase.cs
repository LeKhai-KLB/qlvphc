using Contracts.Domains.Interfaces;

namespace Contracts.Domains
{
    public abstract class EntityAuditBase<T> : EntityBase<T>, IAuditable
    {
        public int NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public int? NguoiCapNhatCuoi { get; set; }
        public DateTime? NgayCapNhatCuoi { get; set; }
    }
}