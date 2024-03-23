using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Common.Models.KetQuaXuPhatTruyCuuHSs;

public class KetQuaXuPhatTruyCuuHSDto : IMapFrom<KetQuaXuPhatTruyCuuHS>
{
    public int Id { get; set; }

    public int HoSoXuLyViPhamId { get; set; }

    public DateTime NgayThiHanh { get; set; }

    public DateTime ThoiHanThiHanh { get; set; }

    public string? NoiDung { get; set; }

    public int CoQuanBanHanhId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<KetQuaXuPhatTruyCuuHS, KetQuaXuPhatTruyCuuHSDto>().ReverseMap();
    }
}