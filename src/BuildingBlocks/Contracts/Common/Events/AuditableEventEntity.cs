using Contracts.Domains.Interfaces;

namespace Contracts.Common.Events
{
    public abstract class AuditableEventEntity<T> : EventEntity<T>, IAuditable
    {
        public DateTime NgayTao { get; set; }
        public DateTime? NgayCapNhatCuoi { get; set; }
        public int NguoiTao { get; set; }
        public int? NguoiCapNhatCuoi { get; set; }
    }
}