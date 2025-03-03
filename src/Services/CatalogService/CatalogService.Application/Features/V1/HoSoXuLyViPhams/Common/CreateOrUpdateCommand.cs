using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.HoSoXuLyViPhams.Queries.GetPagedHoSoXuLyViPham;
using CatalogService.Application.Parameters.HoSoXuLyViPhams;
using CatalogService.Domain.Constants;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.HoSoXuLyViPhams.Common;

public class CreateOrUpdateCommand : IMapFrom<HoSoXuLyViPham>
{
    public string SoHoSo { get; set; }

    public DateTime NgayHoSo { get; set; }

    public string TenHoSo { get; set; }

    public int CaNhanViPhamId { get; set; }

    public bool IsCaNhanViPhamKhac { get; set; }

    public string? ThongTinKhac { get; set; }

    public List<string>? HinhAnhViPhams { get; set; }

    public TrangThaiHoSoViPham TrangThaiHoSoViPham { get; set; }

    public TinhTietViPham TinhTietViPham { get; set; }

    public LoaiVuViecViPham LoaiVuViecViPham { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrUpdateCommand, HoSoXuLyViPham>();
        profile.CreateMap<GetPagedHoSoXuLyViPhamQuery, HoSoXuLyViPhamParameter>();
    }
}