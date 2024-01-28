using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;


namespace CatalogService.Application.Common.Models.DanhMucDinhDanhs
{
    public class DanhMucDinhDanhDto : IMapFrom<DanhMucDinhDanh>
    {
        public int Id { get; set; }
        public string MaDinhDanh { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string? Email { get; set; }
        public string? DienThoai { get; set; }
        public string? Website { get; set; }
        public string? MaDinhDanhTCVN { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DanhMucDinhDanh, DanhMucDinhDanhDto>().ReverseMap();
        }
    }
}