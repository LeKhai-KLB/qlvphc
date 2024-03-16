using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.HanhViViPhams.Queries.GetPagedHanhViViPham;
using CatalogService.Application.Parameters.HanhViViPhams;
using CatalogService.Domain.Constants;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.HanhViViPhams.Common;

public class CreateOrUpdateCommand : IMapFrom<HanhViViPham>
{
    public int? QuyetDinhXuPhatId { get; set; }

    public int? HoSoXuLyViPhamId { get; set; }

    public int LinhVucXuPhatId { get; set; }

    public int DieuKhoanXuPhatId { get; set; }

    public int? DieuKhoanBoSungId { get; set; }

    public int? DieuKhoanKhacPhucId { get; set; }

    public string? QuyDinh { get; set; }

    public TinhTietViPham TinhTietViPham { get; set; }

    public long MucPhat { get; set; }

    public string? GhiChu { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrUpdateCommand, HanhViViPham>();
        profile.CreateMap<GetPagedHanhViViPhamQuery, HanhViViPhamParameter>();
    }
}