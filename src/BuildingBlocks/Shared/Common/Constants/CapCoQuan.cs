using System.ComponentModel;

namespace Shared.Common.Constants;

public enum CapCoQuan
{
    [Description("Xã")]
    Xa,

    [Description("Huyện")]
    Huyen,

    [Description("Cơ quan ngành dọc")]
    CoQuanNganhDoc,

    [Description("Tỉnh")]
    Tinh,

    [Description("Co quan chuyên môn (cấp sở)")]
    CoQuanChuyenMon
}