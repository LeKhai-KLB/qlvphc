using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;


namespace CatalogService.Application.Common.Models.GiayPhepTamGius
{
    public class GiayPhepTamGiuDto : IMapFrom<GiayPhepTamGiu>
    {
        public int Id { get; set; }

        public int HoSoXuLyViPhamId { get; set; }

        public string Ten { get; set; }

        public int SoLuong { get; set; }

        public string TinhTrang { get; set; }

        public string? GhiChu { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GiayPhepTamGiu, GiayPhepTamGiuDto>().ReverseMap();
        }
    }
}