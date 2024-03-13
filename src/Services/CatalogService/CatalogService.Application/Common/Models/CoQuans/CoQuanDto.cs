using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;
using Shared.Common.Constants;

namespace CatalogService.Application.Common.Models.CoQuans;

public class CoQuanDto : IMapFrom<CoQuan>
{
    public int Id { get; set; }

    public string TenCoQuan { get; set; }

    public string DiaChi { get; set; }

    public string DienThoai { get; set; }

    public string Email { get; set; }

    public string Website { get; set; }

    public string SoFax { get; set; }

    public CapCoQuan CapCoQuan { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CoQuan, CoQuanDto>().ReverseMap();
    }
}