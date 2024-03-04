using Shared.SeedWord;

namespace CatalogService.Application.Parameters.ThamQuyenXuPhats;

public class ThamQuyenXuPhatParameter : RequestParameters
{
    public int? DieuKhoanXuPhatId { get; set; }

    public bool? IsDeleted { get; set; }
}