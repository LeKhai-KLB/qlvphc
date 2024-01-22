using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Common.Models.DieuKhoanXuPhats;

public class DieuKhoanXuPhatDto : IMapFrom<DieuKhoanXuPhat>
{
    public int Id { get; set; }

    public int LinhVucXuPhatId { get; set; }
    public string Dieu { get; set; }
    public string Khoan { get; set; }
    public string Diem { get; set; }

    public LinhVucXuPhat LinhVucXuPhat { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DieuKhoanXuPhat, DieuKhoanXuPhatDto>().ReverseMap();
    }
}