using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.TangVatPhuongTienTamGius.Queries.GetTangVatPhuongTienTamGius;
using CatalogService.Application.Parameters.TangVatPhuongTienTamGius;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.TangVatPhuongTienTamGius.Common
{
    public class CreateOrUpdateCommand : IMapFrom<TangVatPhuongTienTamGiu>
    {
        public int HoSoXuLyViPhamId { get; set; }

        public string Ten { get; set; }

        public string DonViTinh { get; set; }

        public int SoLuong { get; set; }

        public string ChungLoai { get; set; }

        public string TinhTrang { get; set; }

        public string? GhiChu { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrUpdateCommand, TangVatPhuongTienTamGiu>();
            profile.CreateMap<GetTangVatPhuongTienTamGiusQuery, TangVatPhuongTienTamGiuParameter>();
        }
    }
}