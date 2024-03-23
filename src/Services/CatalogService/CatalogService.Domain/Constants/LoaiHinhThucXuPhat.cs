using System.ComponentModel;

namespace CatalogService.Domain.Constants;

public enum LoaiHinhThucXuPhat
{
    [Description("Trực tiếp")]
    TrucTiep,

    [Description("Gián tiếp")]
    GianTiep
}