using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.VanBanPhapLuats;
using CatalogService.Application.Features.V1.VanBanPhapLuats.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanPhapLuats.Commands.CreateVanBanPhapLuat;

public class CreateVanBanPhapLuatCommand : CreateOrUpdateCommand, IRequest<ApiResult<VanBanPhapLuatDto>>, IMapFrom<VanBanPhapLuat>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateVanBanPhapLuatDto, CreateVanBanPhapLuatCommand>();
        profile.CreateMap<CreateVanBanPhapLuatCommand, VanBanPhapLuat>();
    }
}