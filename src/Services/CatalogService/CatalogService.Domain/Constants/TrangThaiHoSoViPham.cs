using System.ComponentModel;

namespace CatalogService.Domain.Constants;

public enum TrangThaiHoSoViPham
{
    [Description("Chưa xử lý")]
    ChuaXuLy,

    [Description("Đã xử lý")]
    DaXuLy
}