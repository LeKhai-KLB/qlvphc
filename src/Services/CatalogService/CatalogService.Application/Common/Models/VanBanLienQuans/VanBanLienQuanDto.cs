using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Common.Models.VanBanLienQuans;

public class VanBanLienQuanDto : IMapFrom<VanBanLienQuan>
{
    public int Id { get; set; }

    public int VanBanPhapLuatId { get; set; }

    public DateTime NgayBanHanh { get; set; }

    public string Ten { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<VanBanLienQuan, VanBanLienQuanDto>().ReverseMap();
    }
}