using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Common.Models.ThamQuyenXuPhats;

public class ThamQuyenXuPhatDto : IMapFrom<ThamQuyenXuPhat>
{
    public int Id { get; set; }

    public int DieuKhoanXuPhatId { get; set; }

    public string ThamQuyen { get; set; }

    public DieuKhoanXuPhat DieuKhoanXuPhat { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ThamQuyenXuPhat, ThamQuyenXuPhatDto>().ReverseMap();
    }
}