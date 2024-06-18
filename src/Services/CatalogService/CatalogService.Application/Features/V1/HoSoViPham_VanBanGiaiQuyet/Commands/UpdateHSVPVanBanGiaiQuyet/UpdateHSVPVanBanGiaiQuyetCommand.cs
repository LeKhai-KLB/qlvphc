using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Commands.UpdateHSVPVanBanGiaiQuyet;

public class UpdateHoSoXuLyViPham_VanBanGiaiQuyetCommand : CreateOrUpdateCommand, IRequest<ApiResult<HoSoXuLyViPham_VanBanGiaiQuyetDto>>, IMapFrom<HoSoXuLyViPham_VanBanGiaiQuyet>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateHoSoXuLyViPham_VanBanGiaiQuyetCommand, HoSoXuLyViPham_VanBanGiaiQuyet>().IgnoreAllNonExisting();
    }
}