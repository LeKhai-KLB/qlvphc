using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Commands.UpdateHSVPVanBanGiaiQuyet;

public class UpdateHSVPVanBanGiaiQuyetCommand : CreateOrUpdateCommand, IRequest<ApiResult<HoSoViPham_VanBanGiaiQuyetDto>>, IMapFrom<HoSoXuLyViPham_VanBanGiaiQuyet>
{
    public int HoSoXuLyViPhamId { get; set; }

    public int VanBanGiaiQuyetId { get; set; }

    public void SetId(int hoxulyviphamId, int vanbangiaiquyetId)
    {
        HoSoXuLyViPhamId = hoxulyviphamId;
        VanBanGiaiQuyetId = vanbangiaiquyetId;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateHSVPVanBanGiaiQuyetCommand, HoSoXuLyViPham_VanBanGiaiQuyet>().IgnoreAllNonExisting();
    }
}