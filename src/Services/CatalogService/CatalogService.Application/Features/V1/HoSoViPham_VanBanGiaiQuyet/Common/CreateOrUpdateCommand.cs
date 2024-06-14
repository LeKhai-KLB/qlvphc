using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Queries.GetPagedVanBanByHSVPId;
using CatalogService.Application.Parameters.HoSoXuLyViPhams;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Common;

public class CreateOrUpdateCommand : IMapFrom<HoSoXuLyViPham_VanBanGiaiQuyet>
{
    public int HoSoXuLyViPhamId { get; set; }

    public int VanBanGiaiQuyetId { get; set; }

    public string SoQuyetDinh { get; set; }

    public DateTime NgayNhap { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrUpdateCommand, HoSoXuLyViPham_VanBanGiaiQuyet>();
        profile.CreateMap<GetPagedVanBanByHSVPIdQuery, HSVPVanBanGiaiQuyetParameter>();
    }
}