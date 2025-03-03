using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Common.Models.HoSoXuLyViPhams;

public class HoSoXuLyViPham_VanBanGiaiQuyetDto : IMapFrom<HoSoXuLyViPham_VanBanGiaiQuyet>
{
    public int Id { get; set; }
    public int HoSoXuLyViPhamId { get; set; }

    public int VanBanGiaiQuyetId { get; set; }

    public string SoQuyetDinh { get; set; }

    public DateTime NgayNhap { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<HoSoXuLyViPham_VanBanGiaiQuyet, HoSoXuLyViPham_VanBanGiaiQuyetDto>().ReverseMap();
    }
}