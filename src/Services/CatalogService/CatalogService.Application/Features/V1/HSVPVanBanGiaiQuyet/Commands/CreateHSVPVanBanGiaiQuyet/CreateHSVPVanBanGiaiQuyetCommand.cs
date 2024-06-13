using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Commands.CreateHSVPVanBanGiaiQuyet;

public class CreateHSVPVanBanGiaiQuyetCommand : CreateOrUpdateCommand, IRequest<ApiResult<HSVPVanBanGiaiQuyetDto>>, IMapFrom<HoSoXuLyViPham_VanBanGiaiQuyet>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateHSVPVanBanGiaiQuyetDto, CreateHSVPVanBanGiaiQuyetCommand>();
        profile.CreateMap<CreateHSVPVanBanGiaiQuyetCommand, HoSoXuLyViPham_VanBanGiaiQuyet>();
    }
}