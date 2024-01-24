using Shared.SeedWord;

namespace CatalogService.Application.Parameters.LinhVucXuPhats;

public class LinhVucXuPhatParameter : RequestParameters
{
    public string? TenLinhVuc { get; set; }

    public string? NhomLinhVuc { get; set; }
}