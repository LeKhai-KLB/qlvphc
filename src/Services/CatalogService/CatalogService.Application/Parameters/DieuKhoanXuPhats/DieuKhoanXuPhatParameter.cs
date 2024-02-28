using Shared.SeedWord;

namespace CatalogService.Application.Parameters.DieuKhoanXuPhats;

public class DieuKhoanXuPhatParameter : RequestParameters
{
    public string? Name { get; set; }
    public bool? IsDeleted { get; set; }
}