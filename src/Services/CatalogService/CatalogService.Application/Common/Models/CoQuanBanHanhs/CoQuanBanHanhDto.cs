using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Common.Models.CoQuanBanHanhs;

public class CoQuanBanHanhDto : IMapFrom<CoQuanBanHanh>
{
    public int Id { get; set; }

    public string NhomCoQuan { get; set; }

    public string TenCoQuan { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CoQuanBanHanh, CoQuanBanHanhDto>().ReverseMap();
    }
}