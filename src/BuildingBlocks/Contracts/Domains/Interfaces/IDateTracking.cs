namespace Contracts.Domains.Interfaces
{
    public interface IDateTracking
    {
        int NguoiTao { get; set; }
        DateTime NgayTao { get; set; }
        int? NguoiCapNhatCuoi { get; set; }
        DateTime? NgayCapNhatCuoi { get; set; }
    }
}
