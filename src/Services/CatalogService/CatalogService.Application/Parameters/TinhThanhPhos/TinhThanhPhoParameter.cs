using Shared.SeedWord;

namespace CatalogService.Application.Parameters.TinhThanhPhos;

public class TinhThanhPhoParameter : RequestParameters
{
    public string? Name { get; set; }
    public bool? IsDeleted { get; set; }
}