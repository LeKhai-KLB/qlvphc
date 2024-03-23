using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Common.Models.KhoBacs;

public class KhoBacDto : IMapFrom<KhoBac>
{
    public int Id { get; set; }

    public string TenKhoBac { get; set; }

    public string? TaiKhoan { get; set; }

    public string? DiaChi { get; set; }

    public string? DiaDiemGiaoDich { get; set; }

    public string? TenCoQuan { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<KhoBac, KhoBacDto>().ReverseMap();
    }
}