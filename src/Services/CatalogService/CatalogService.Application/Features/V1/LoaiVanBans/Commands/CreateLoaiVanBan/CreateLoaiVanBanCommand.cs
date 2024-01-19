using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.LoaiVanBans;
using CatalogService.Application.Features.V1.LoaiVanBans.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LoaiVanBans.Commands.CreateLoaiVanBan;

public class CreateLoaiVanBanCommand : CreateOrUpdateCommand, IRequest<ApiResult<LoaiVanBanDto>>, IMapFrom<LoaiVanBan>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateLoaiVanBanDto, CreateLoaiVanBanCommand>();
        profile.CreateMap<CreateLoaiVanBanCommand, LoaiVanBan>();
    }
}