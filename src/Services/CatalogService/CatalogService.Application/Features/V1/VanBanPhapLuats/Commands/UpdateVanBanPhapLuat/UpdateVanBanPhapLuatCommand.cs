using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.VanBanPhapLuats;
using CatalogService.Application.Features.V1.VanBanPhapLuats.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanPhapLuats.Commands.UpdateVanBanPhapLuat;

public class UpdateVanBanPhapLuatCommand : CreateOrUpdateCommand, IRequest<ApiResult<VanBanPhapLuatDto>>, IMapFrom<VanBanPhapLuat>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateVanBanPhapLuatCommand, VanBanPhapLuat>().IgnoreAllNonExisting();
    }
}