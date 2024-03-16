using Shared.SeedWord;

namespace CatalogService.Application.Parameters.HanhViViPhams;

public class HanhViViPhamParameter : RequestParameters
{
    public int? QuyetDinhXuPhatId { get; set; }

    public int? HoSoXuLyViPhamId { get; set; }
}