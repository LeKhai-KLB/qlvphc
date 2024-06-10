using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Constants;
using CatalogService.Domain.Entities;
using Newtonsoft.Json;

namespace CatalogService.Application.Common.Models.HoSoXuLyViPhams;

public class HoSoXuLyViPhamDto : IMapFrom<HoSoXuLyViPham>
{
    public int Id { get; set; }

    public string SoHoSo { get; set; }

    public DateTime NgayHoSo { get; set; }

    public string TenHoSo { get; set; }

    public int? CaNhanViPhamId { get; set; }

    public bool IsCaNhanViPhamKhac { get; set; }

    public string? ThongTinKhac { get; set; }

    public List<string>? HinhAnhViPhams { get; set; }

    public TrangThaiHoSoViPham TrangThaiHoSoViPham { get; set; }

    public TinhTietViPham TinhTietViPham { get; set; }

    public LoaiVuViecViPham LoaiVuViecViPham { get; set; }

    public List<string> HanhViViPhams { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<HoSoXuLyViPham, HoSoXuLyViPhamDto>()
            .ForMember(dest => dest.HinhAnhViPhams, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.HinhAnhViPham)
                                                                        ? JsonConvert.DeserializeObject<List<string>>(src.HinhAnhViPham) : null));
    }
}