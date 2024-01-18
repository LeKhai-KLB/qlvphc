namespace CatalogService.Application.Common.Models.VanBanLienQuans;

public class CreateVanBanLienQuanDto
{
    public int VanBanPhapLuatId { get; set; }

    public DateTime NgayBanHanh { get; set; }

    public string Ten { get; set; }
}