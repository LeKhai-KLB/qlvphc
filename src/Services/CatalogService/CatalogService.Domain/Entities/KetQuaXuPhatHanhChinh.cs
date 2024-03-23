using CatalogService.Domain.Constants;
using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class KetQuaXuPhatHanhChinh : EntityAuditBase<int>
{
    public int HoSoXuLyViPhamId { get; set; }

    public int QuyetDinhXuPhatId { get; set; }

    public LoaiKetQuaXuPhat LoaiKetQuaXuPhat { get; set; }

    public DateTime NgayNhap { get; set; }

    public DateTime ThoiHanThiHanh { get; set; }

    public long SoTienThu { get; set; }

    public long SoTienChamNop { get; set; }

    public long SoTienBanTangVat { get; set; }

    public long SoTienDaThuTuBanTangVat { get; set; }

    public long SoTienKhac { get; set; }

    public string? NoiDung { get; set; }

    public string? ThongBaoChapHanh { get; set; }
}