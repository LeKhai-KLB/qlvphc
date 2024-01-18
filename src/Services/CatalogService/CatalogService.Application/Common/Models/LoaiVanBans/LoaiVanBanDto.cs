using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Common.Models.LoaiVanBans;

public class LoaiVanBanDto : IMapFrom<LoaiVanBan>
{
    public int Id { get; set; }

    public string Ten { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<LoaiVanBan, LoaiVanBanDto>().ReverseMap();
    }
}