using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.LoaiVanBans;
using CatalogService.Application.Features.V1.LoaiVanBans.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LoaiVanBans.Commands.UpdateLoaiVanBan;

public class UpdateLoaiVanBanCommand : CreateOrUpdateCommand, IRequest<ApiResult<LoaiVanBanDto>>, IMapFrom<LoaiVanBan>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateLoaiVanBanCommand, LoaiVanBan>().IgnoreAllNonExisting();
    }
}