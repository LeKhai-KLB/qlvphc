using Shared.SeedWord;

namespace CatalogService.Application.Parameters.CoQuanBanHanhs;

public class CoQuanBanHanhParameter : RequestParameters
{
    public string? NhomCoQuan { get; set; }

    public string? TenCoQuan { get; set; }
}