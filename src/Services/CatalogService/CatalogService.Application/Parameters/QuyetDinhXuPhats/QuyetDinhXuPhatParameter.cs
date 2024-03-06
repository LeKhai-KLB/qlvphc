using Shared.SeedWord;

namespace CatalogService.Application.Parameters.QuyetDinhXuPhats
{
    public class QuyetDinhXuPhatParameter : RequestParameters
    {
        public string? SoQuyetDinh { get; set; }
        public bool? IsDeleted { get; set; }
    }
}