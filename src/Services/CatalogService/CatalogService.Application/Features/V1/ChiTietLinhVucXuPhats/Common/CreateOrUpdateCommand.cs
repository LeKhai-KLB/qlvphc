using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Common;

public class CreateOrUpdateCommand : IMapFrom<ChiTietLinhVucXuPhat>
{
    public int LinhVucXuPhatId { get; set; }

    public string DieuKhoan { get; set; }

    public string Diem { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrUpdateCommand, ChiTietLinhVucXuPhat>();
    }
}