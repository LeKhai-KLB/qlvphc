using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.CongDans.Queries.GetPagedCongDan;
using CatalogService.Application.Parameters.CongDans;
using CatalogService.Domain.Entities;
using Shared.Common.Constants;

namespace CatalogService.Application.Features.V1.CongDans.Common;

public class CreateOrUpdateCommand : IMapFrom<CongDan>
{
    public string HoTen { get; set; }

    public DateTime NgaySinh { get; set; }

    public Genders GioiTinh { get; set; }

    public DanToc? DanToc { get; set; }

    public string? QuocTich { get; set; }

    public string? NgheNghiep { get; set; }

    public string? QueQuan { get; set; }

    public string? DiaChi { get; set; }

    public LoaiGiayToDinhDanh LoaiGiayToDinhDanh { get; set; }

    public string SoLoaiGiayTo { get; set; }

    public string? NoiCap { get; set; }

    public DateTime? NgayCap { get; set; }

    public string? HocVan { get; set; }

    public string? DienThoai { get; set; }

    public string? TenGoiKhac { get; set; }

    public string? Email { get; set; }

    public string? NoiLamViec { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrUpdateCommand, CongDan>();
        profile.CreateMap<GetPagedCongDanQuery, CongDanParameter>();
    }
}