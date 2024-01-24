using Shared.SeedWord;

namespace CatalogService.Application.Parameters.VanBanGiaiQuyets;

public class VanBanGiaiQuyetParameter : RequestParameters
{
    public string? MaGiayTo { get; set; }

    public string? TheoNghiDinh { get; set; }

    public string? TenGiayTo { get; set; }
}