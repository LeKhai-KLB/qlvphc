using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.VanBanGiaiQuyets;
using CatalogService.Application.Features.V1.VanBanGiaiQuyets.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanGiaiQuyets.Commands.CreateVanBanGiaiQuyet;

public class CreateVanBanGiaiQuyetCommand : CreateOrUpdateCommand, IRequest<ApiResult<VanBanGiaiQuyetDto>>, IMapFrom<VanBanGiaiQuyet>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateVanBanGiaiQuyetDto, CreateVanBanGiaiQuyetCommand>();
        profile.CreateMap<CreateVanBanGiaiQuyetCommand, VanBanGiaiQuyet>();
    }
}