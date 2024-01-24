using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.VanBanGiaiQuyets;
using CatalogService.Application.Features.V1.VanBanGiaiQuyets.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanGiaiQuyets.Commands.UpdateVanBanGiaiQuyet;

public class UpdateVanBanGiaiQuyetCommand : CreateOrUpdateCommand, IRequest<ApiResult<VanBanGiaiQuyetDto>>, IMapFrom<VanBanGiaiQuyet>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateVanBanGiaiQuyetCommand, VanBanGiaiQuyet>().IgnoreAllNonExisting();
    }
}