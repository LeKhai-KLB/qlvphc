using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.LoaiVanBans.Queries.GetPagedLoaiVanBanAsync;
using CatalogService.Application.Parameters.LoaiVanBans;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.LoaiVanBans.Common;

public class CreateOrUpdateCommand : IMapFrom<LoaiVanBan>
{
    public string Ten { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrUpdateCommand, LoaiVanBan>();
        profile.CreateMap<GetPagedLoaiVanBanQuery, LoaiVanBanParameter>();
    }
}