using AutoMapper;
using DanhMucService.Application.Common.Mappings;
using DanhMucService.Domain.Entities;


namespace DanhMucService.Application.Common.Models.XaPhuongs
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