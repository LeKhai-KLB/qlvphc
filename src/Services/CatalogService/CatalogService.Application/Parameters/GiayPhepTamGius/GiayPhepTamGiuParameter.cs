using Shared.SeedWord;

namespace CatalogService.Application.Parameters.GiayPhepTamGius
{
    public class GiayPhepTamGiuParameter : RequestParameters
    {
        public string? Ten { get; set; }
        public bool? IsDeleted { get; set; }
    }
}