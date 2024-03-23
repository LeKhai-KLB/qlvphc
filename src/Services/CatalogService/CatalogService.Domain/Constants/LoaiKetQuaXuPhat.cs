using System.ComponentModel;

namespace CatalogService.Domain.Constants;

public enum LoaiKetQuaXuPhat
{
    [Description("Đã thi hành")]
    DTH,

    [Description("Chưa thi hành xong")]
    CTHX,

    [Description("Đình chỉ thi hành xong")]
    DCTHX,

    [Description("Tạm đình chỉ thi hành")]
    TDCTH,

    [Description("Hoãn thi hành quyết định phạt tiền")]
    HTHQDPT,

    [Description("Miễn thi hành quyết định phạt tiền")]
    MTHQDPT,

    [Description("Giảm phạt tiền")]
    GPT,

    [Description("Cưỡng chế thi hành")]
    CCTH,

    [Description("Khiếu nại")]
    KN,

    [Description("Khởi kiện")]
    KK,

    [Description("Hết thời hiệu")]
    HTH,

    [Description("Quyết định sai bị thu hồi")]
    QDSBTH,

    [Description("Quyết định sai bị sửa đổi")]
    QDSBSD,

    [Description("Chấp hành hoàn toàn")]
    CHHT,

    [Description("Chấp hành chưa khắc phục hậu quả")]
    CHCKPHQ,

    [Description("Chấp hành một phần")]
    CHMP,

    [Description("Chưa chấp hành")]
    CCH,

    [Description("Chưa chấp hành khắc phục hậu quả")]
    CCHKPHQ
}