using System.ComponentModel;

namespace Shared.Common.Constants;

public enum LoaiGiayToDinhDanh
{
    [Description("Thẻ căn cước công dân")]
    CCCD,

    [Description("Chứng minh nhân dân")]
    CMND,

    [Description("Hộ chiếu")]
    PP,

    [Description("Khác")]
    Other
}