using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Common.Models.ChiTietLinhVucXuPhats;

public class ChiTietLinhVucXuPhatDto : IMapFrom<ChiTietLinhVucXuPhat>
{
    public int Id { get; set; }

    public int LinhVucXuPhatId { get; set; }

    public string DieuKhoan { get; set; }

    public string Diem { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ChiTietLinhVucXuPhat, ChiTietLinhVucXuPhatDto>().ReverseMap();
    }
}