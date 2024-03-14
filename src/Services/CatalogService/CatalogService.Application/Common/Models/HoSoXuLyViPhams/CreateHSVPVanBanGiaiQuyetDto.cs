namespace CatalogService.Application.Common.Models.HoSoXuLyViPhams;

public class CreateHSVPVanBanGiaiQuyetDto
{
    public int HoSoXuLyViPhamId { get; set; }

    public int VanBanGiaiQuyetId { get; set; }

    public string SoQuyetDinh { get; set; }

    public DateTime NgayNhap { get; set; }
}