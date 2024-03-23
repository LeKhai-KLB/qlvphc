using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.Users;
using CatalogService.Domain.Constants;
using CatalogService.Domain.Entities;
using Shared.Common.Helpers;

namespace CatalogService.Application.Common.Models.QuyetDinhXuPhats;

public class QuyetDinhXuPhatDto : IMapFrom<QuyetDinhXuPhat>
{
    public int Id { get; set; }

    public int HoSoXuLyViPhamId { get; set; }

    public LoaiHinhThucXuPhat LoaiHinhThucXuPhat { get; set; }

    public DateTime NgayNhapQuyetDinh { get; set; }

    public string SoQuyetDinh { get; set; }

    public DateTime NgayQuyetDinh { get; set; }

    public DateTime HieuLucThiHanhNgay { get; set; }

    public int CoQuanBanHanhId { get; set; }

    public Guid NguoiRaQuyetDinhId { get; set; }

    public int LoaiDoiTuongViPham { get; set; }

    public int DoiTuongViPhamId { get; set; }

    public string? DoiTuongViPhamKhac { get; set; }

    public string CanCuVanBan { get; set; }

    public string CanCuQuyDinh { get; set; }
    public long? SoTienPhat { get; set; }

    public string? SoTienPhatBangChu { get; set; }
    public long? TienKhacPhuc { get; set; }

    public string? NoiThucHien { get; set; }
    public long? TienTruyThu { get; set; }
    public int? ThoiHanKhacPhucHauQua { get; set; }
    public int? ThoiHanThucHienXuPhatBoSung { get; set; }

    public int NoiNopTienPhat { get; set; }

    public string? NoiNopTienPhatTuNhap { get; set; }

    public string DiaDiemViPham { get; set; }

    public int HinhThucXuPhatChinh { get; set; }

    public string? TinhTietTangNang { get; set; }

    public string? TinhTietGiamNhe { get; set; }

    public string HinhThucXuPhatCuThe { get; set; }

    public string? HinhThucXuPhatBoSungEnums { get; set; }

    public List<int> HinhThucXuPhatBoSungs { get; set; }

    public string? HinhThucXuPhatBoSungCuThe { get; set; }

    public string? BienPhapKhacPhucHauQuaEnums { get; set; }
    public List<int> BienPhapKhacPhucHauQuas { get; set; }

    public string? BienPhapKhacPhucHauQuaCuThe { get; set; }

    public string? NoiDungLienQuanKhacPhucHauQua { get; set; }

    public string DonViPhoiHopThucHien { get; set; }

    public string NoiNhan { get; set; }

    public List<HanhViViPham> HanhViViPhams { get; set; }

    public CoQuanBanHanh CoQuanBanHanh { get; set; }

    public UserDto NguoiRaQuyetDinh { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<QuyetDinhXuPhat, QuyetDinhXuPhatDto>()
            .ForMember(dest => dest.HinhThucXuPhatBoSungs, opt => opt.MapFrom(src => EnumConverter.StringToList<HinhThucXuPhatBoSungEnum>(src.HinhThucXuPhatBoSungEnums)))
            .ForMember(dest => dest.BienPhapKhacPhucHauQuas, opt => opt.MapFrom(src => EnumConverter.StringToList<BienPhapKhacPhucHauQuaEnum>(src.BienPhapKhacPhucHauQuaEnums)))
            .ReverseMap();
    }
}