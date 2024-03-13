using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Common.Models.CongDans;

public class CongDanDropDownDto : IMapFrom<CongDan>
{
    public int Id { get; set; }

    public string HoTen { get; set; }

    public DateTime NgaySinh { get; set; }

    public string? DiaChi { get; set; }

    public string SoLoaiGiayTo { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CongDan, CongDanDropDownDto>().ReverseMap();
    }
}