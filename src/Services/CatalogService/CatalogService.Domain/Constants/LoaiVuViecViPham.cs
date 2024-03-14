using System.ComponentModel;

namespace CatalogService.Domain.Constants;

public enum LoaiVuViecViPham
{
    [Description("Xử phạt vi phạm hành chính")]
    XPVPHC,

    [Description("Cơ quan có thẩm quyền tiến hành tố tụng hình sự chuyển đến để xử phạt vi phạm hành chính")]
    CQCOTQ,

    [Description("Chuyển truy cứu trách nhiệm hình sự")]
    CTCTNHS,

    [Description("Lập hồ sơ đề nghị giáo dục tại xã phường, thị trấn")]
    LHSGDPX,

    [Description("Lập hồ sơ đề nghị đưa vào trường giáo dưỡng")]
    LHSTGD,

    [Description("Lập hồ sơ đề nghị đưa vào cơ sở giáo dục bắt buộc")]
    LHSCSGDBB,

    [Description("Lập hồ sơ đề nghị giáo dục tại cơ sở cai nghiện bắt buộc")]
    LHSCSCNBB,

    [Description("Biện pháp XLHC giáo dục tại xã, phường, thị trấn")]
    BPXLHCPX,

    [Description("Biện pháp XLHC đưa vào trường giáo dưỡng")]
    BPXLHCTGD,

    [Description("Biện pháp XLHC đưa vào cơ sở giáo dục bắt buộc")]
    BPXLHCCSGDBB,

    [Description("Biện pháp XLHC đưa vào cơ sở cai nghiện bắt buộc")]
    BPXLHCCSCNBB,

    [Description("Biện pháp TTQL tại gia đình tại xã, phường, thị trấn")]
    BPTTQLGDPX,

    [Description("Biện pháp TTQL tại gia đình đưa vào trường giáo dưỡng")]
    BPTTQLGDTGD,

    [Description("Biện pháp TTQL tại gia đình tại đưa vào cơ sở giáo dục bắt buộc")]
    BPTTQLGDCSGDBB,

    [Description("Biện pháp TTQL tại gia đình tại đưa vào cơ sở cai nghiện bắt buộc")]
    BPTTQLGDCSCNBB,

    [Description("Áp dụng biện pháp thay thế giáo dục dựa vào cộng đồng")]
    BPTTGDCD,

    [Description("Áp dụng biện pháp thay thế nhắc nhở đối với người chưa thành niên")]
    BPTTNNNCTN
}