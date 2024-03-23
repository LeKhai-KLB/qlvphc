using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Queries.GetPagedKetQuaXuPhatHanhChinh;
using CatalogService.Application.Parameters.KetQuaXuPhatHanhChinhs;
using CatalogService.Domain.Constants;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Common;

public class CreateOrUpdateCommand : IMapFrom<KetQuaXuPhatHanhChinh>
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

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrUpdateCommand, KetQuaXuPhatHanhChinh>();
        profile.CreateMap<GetPagedKetQuaXuPhatHanhChinhQuery, KetQuaXuPhatHanhChinhParameter>();
    }
}