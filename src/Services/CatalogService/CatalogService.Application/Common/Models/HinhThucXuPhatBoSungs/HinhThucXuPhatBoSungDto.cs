using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;


namespace CatalogService.Application.Common.Models.HinhThucXuPhatBoSungs
{
    public class HinhThucXuPhatBoSungDto : IMapFrom<HinhThucXuPhatBoSung>
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<HinhThucXuPhatBoSung, HinhThucXuPhatBoSungDto>().ReverseMap();
        }
    }
}