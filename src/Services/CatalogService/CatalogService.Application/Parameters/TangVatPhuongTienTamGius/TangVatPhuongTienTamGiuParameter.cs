using Shared.SeedWord;

namespace CatalogService.Application.Parameters.TangVatPhuongTienTamGius
{
    public class TangVatPhuongTienTamGiuParameter : RequestParameters
    {
        public string? Ten { get; set; }
        public bool? IsDeleted { get; set; }
    }
}