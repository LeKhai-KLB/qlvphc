using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.GiayPhepTamGius.Queries.GetGiayPhepTamGius;
using CatalogService.Application.Parameters.GiayPhepTamGius;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.GiayPhepTamGius.Common
{
    public class CreateOrUpdateCommand : IMapFrom<GiayPhepTamGiu>
    {
        public int HoSoXuLyViPhamId { get; set; }

        public string Ten { get; set; }

        public int SoLuong { get; set; }

        public string TinhTrang { get; set; }

        public string? GhiChu { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrUpdateCommand, GiayPhepTamGiu>();
            profile.CreateMap<GetGiayPhepTamGiusQuery, GiayPhepTamGiuParameter>();
        }
    }
}