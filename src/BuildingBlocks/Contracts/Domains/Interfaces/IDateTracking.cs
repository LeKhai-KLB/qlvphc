namespace Contracts.Domains.Interfaces
{
    public interface IDateTracking
    {
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int? LastModifiedBy { get; set; }
        DateTime? LastModifiedDate { get; set; }
    }
}
