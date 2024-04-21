using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Queries.GetAllDieuKhoanBoSungKhacPhucs;
using CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Queries.GetPagedDieuKhoanBoSungKhacPhuc;
using CatalogService.Application.Parameters.DieuKhoanBoSungKhacPhucs;
using CatalogService.Domain.Constants;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Common;

public class CreateOrUpdateCommand : IMapFrom<DieuKhoanBoSungKhacPhuc>
{
    public int DieuKhoanXuPhatId { get; set; }
    public string? Dieu { get; set; }
    public string? Khoan { get; set; }
    public string? Diem { get; set; }
    public LoaiDieuKhoan? LoaiDieuKhoan { get; set; }
    public bool? IsDeleted { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrUpdateCommand, DieuKhoanBoSungKhacPhuc>();
        profile.CreateMap<GetPagedDieuKhoanBoSungKhacPhucQuery, DieuKhoanBoSungKhacPhucParameter>();
        profile.CreateMap<GetAllDieuKhoanBoSungKhacPhucsQuery, DieuKhoanBoSungKhacPhucDropDownParameter>();
    }
}