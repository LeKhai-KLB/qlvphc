using Shared.SeedWord;

namespace CatalogService.Application.Parameters.ThamQuyenXuPhats;

public class ThamQuyenXuPhatParameter : RequestParameters
{
    public string? ThamQuyen { get; set; }

    public bool? IsDeleted { get; set; }
}