using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.ToChucs.Queries.GetPagedToChuc;
using CatalogService.Application.Parameters.ToChucs;
using CatalogService.Domain.Entities;
using Shared.Common.Constants;

namespace CatalogService.Application.Features.V1.ToChucs.Common;

public class CreateOrUpdateCommand : IMapFrom<ToChuc>
{
    public string TenTC { get; set; }

    public string? DiaChi { get; set; }

    public string? MaSo { get; set; }

    public string? SoChungNhan { get; set; }

    public string? GiayPhepSo { get; set; }

    public DateTime? NgayGiayPhep { get; set; }

    public string? NoiCap { get; set; }

    public string? TenNguoiDaiDien { get; set; }

    public Genders? GioiTinh { get; set; }

    public string? ChucDanh { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrUpdateCommand, ToChuc>();
        profile.CreateMap<GetPagedToChucQuery, ToChucParameter>();
    }
}