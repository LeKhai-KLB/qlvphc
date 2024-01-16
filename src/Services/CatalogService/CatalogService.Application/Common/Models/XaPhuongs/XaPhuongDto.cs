using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;


namespace CatalogService.Application.Common.Models.XaPhuongs
{
    public class XaPhuongDto : IMapFrom<XaPhuong>
    {
        public int Id { get; set; }
        public string MaDinhDanh { get; set; }
        public string Ten { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<XaPhuong, XaPhuongDto>().ReverseMap();
        }
    }
}