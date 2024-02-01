using Shared.SeedWord;

namespace CatalogService.Application.Parameters.QuanHuyens
{
    public class QuanHuyenParameter : RequestParameters
    {
        public string? Name { get; set; }
        public bool? IsDeleted { get; set; }
    }
}