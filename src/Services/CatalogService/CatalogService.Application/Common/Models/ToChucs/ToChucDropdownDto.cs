using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Common.Models.ToChucs;

public class ToChucDropdownDto : IMapFrom<ToChuc>
{
    public int Id { get; set; }

    public string TenTC { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ToChuc, ToChucDropdownDto>().ReverseMap();
    }
}