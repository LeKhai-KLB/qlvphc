using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Constants;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Common.Models.DieuKhoanBoSungKhacPhucs;

public class DieuKhoanBoSungKhacPhucDto : IMapFrom<DieuKhoanBoSungKhacPhuc>
{
    public int Id { get; set; }

    public int DieuKhoanXuPhatId { get; set; }

    public string? Dieu { get; set; }

    public string? Khoan { get; set; }

    public string? Diem { get; set; }

    public LoaiDieuKhoan LoaiDieuKhoan { get; set; }

    public bool? IsDeleted { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DieuKhoanBoSungKhacPhuc, DieuKhoanBoSungKhacPhucDto>().ReverseMap();
    }
}