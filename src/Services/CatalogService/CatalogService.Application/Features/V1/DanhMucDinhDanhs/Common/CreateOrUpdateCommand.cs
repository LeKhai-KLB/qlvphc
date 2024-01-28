using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.DanhMucDinhDanhs.Queries.GetDanhMucDinhDanhs;
using CatalogService.Application.Parameters.DanhMucDinhDanhs;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.DanhMucDinhDanhs.Common
{
    public class CreateOrUpdateCommand : IMapFrom<DanhMucDinhDanh>
    {
        public string MaDinhDanh { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string? Email { get; set; }
        public string? DienThoai { get; set; }
        public string? Website { get; set; }
        public string? MaDinhDanhTCVN { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrUpdateCommand, DanhMucDinhDanh>();
            profile.CreateMap<GetDanhMucDinhDanhsQuery, DanhMucDinhDanhParameter>();
        }
    }
}