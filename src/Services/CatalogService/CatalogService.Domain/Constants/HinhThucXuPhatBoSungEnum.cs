using System.ComponentModel;

namespace CatalogService.Domain.Constants;

public enum HinhThucXuPhatBoSungEnum
{
    [Description("Tịch thu tang vật, phương tiện")]
    TTTVPT,

    [Description("Tước quyền sử dụng giấy phép, chứng chỉ hành nghề có thời hạn")]
    TQSDGPCCHNCTH,

    [Description("Đình chỉ hoạt động có thời hạn")]
    DCHDCOTH,

    [Description("Trục xuất")]
    TX
}