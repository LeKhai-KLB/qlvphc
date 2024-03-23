using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Constants;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Common.Models.KetQuaXuPhatHanhChinhs;

public class KetQuaXuPhatHanhChinhDto : IMapFrom<KetQuaXuPhatHanhChinh>
{
    public int Id { get; set; }

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

    public void Mapping(Profile profile)
    {
        profile.CreateMap<KetQuaXuPhatHanhChinh, KetQuaXuPhatHanhChinhDto>().ReverseMap();
    }
}