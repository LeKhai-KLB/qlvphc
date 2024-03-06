using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;


namespace CatalogService.Application.Common.Models.HinhThucXuPhatChinhs
{
    public class HinhThucXuPhatChinhDto : IMapFrom<HinhThucXuPhatChinh>
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<HinhThucXuPhatChinh, HinhThucXuPhatChinhDto>().ReverseMap();
        }
    }
}