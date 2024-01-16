using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;


namespace CatalogService.Application.Common.Models.QuanHuyens
{
    public class QuanHuyenDto : IMapFrom<QuanHuyen>
    {
        public int Id { get; set; }
        public string MaDinhDanh { get; set; }
        public string Ten { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<QuanHuyen, QuanHuyenDto>().ReverseMap();
        }
    }
}