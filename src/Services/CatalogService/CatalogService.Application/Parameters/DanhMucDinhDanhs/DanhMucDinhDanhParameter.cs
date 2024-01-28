using Shared.SeedWord;

namespace CatalogService.Application.Parameters.DanhMucDinhDanhs
{
    public class DanhMucDinhDanhParameter : RequestParameters
    {
        public string? Name { get; set; }
        public bool? IsDeleted { get; set; }
    }
}