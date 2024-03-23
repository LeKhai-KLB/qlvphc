using System.ComponentModel;

namespace CatalogService.Domain.Constants;

public enum BienPhapKhacPhucHauQuaEnum
{
    [Description("Khôi phục lại tình trạng ban đầu")]
    KPLTTBD,

    [Description("Khắc phục tình trạng ô nhiễm môi trường, lây lan dịch bệnh")]
    HPTTONMTLLDB,

    [Description("Tiêu hủy hàng hóa, vật phẩm gây hại, văn hóa phẩm có nội dung độc hại")]
    THHHVPGH,

    [Description("Tháo dỡ công trình vi phạm")]
    TDCTVP,

    [Description("Đưa ra khỏi lãnh thổ Việt Nam hoặc tái xuất hàng hóa, vật phẩm, phương tiện")]
    DRKLTVN,

    [Description("Cải chính thông tin")]
    CCTT,

    [Description("Loại bỏ yếu tố vi phạm trên hàng hóa, bao bì hàng hóa, phương tiện kinh doanh, vật phẩm")]
    LBYTVPTHH,

    [Description("Thu hồi sản phẩm, hàng hóa không đảm bảo chất lượng")]
    THSPHHKDBCL,

    [Description("Các biện pháp khắc phục hậu quả khác")]
    Khac
}