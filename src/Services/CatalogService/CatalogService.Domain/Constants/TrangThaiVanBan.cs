using System.ComponentModel;

namespace CatalogService.Domain.Constants;

public enum TrangThaiVanBan
{
	[Description("Còn hiệu lực")]
	ConHieuLuc,

    [Description("Hết hiệu lực")]
    HetHieuLuc
}