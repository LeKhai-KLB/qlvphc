using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Commands.CreateHSVPVanBanGiaiQuyet;

public class CreateHoSoXuLyViPham_VanBanGiaiQuyetCommand : CreateOrUpdateCommand, IRequest<ApiResult<HoSoXuLyViPham_VanBanGiaiQuyetDto>>, IMapFrom<HoSoXuLyViPham_VanBanGiaiQuyet>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateHoSoXuLyViPham_VanBanGiaiQuyetDto, CreateHoSoXuLyViPham_VanBanGiaiQuyetCommand>();
        profile.CreateMap<CreateHoSoXuLyViPham_VanBanGiaiQuyetCommand, HoSoXuLyViPham_VanBanGiaiQuyet>();
    }
}