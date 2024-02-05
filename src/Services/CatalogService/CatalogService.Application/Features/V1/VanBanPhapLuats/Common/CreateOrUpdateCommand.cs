using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.VanBanPhapLuats.Queries.GetPagedVanBanPhapLuatAsync;
using CatalogService.Application.Parameters.VanBanPhapLuats;
using CatalogService.Domain.Constants;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.VanBanPhapLuats.Common;

public class CreateOrUpdateCommand : IMapFrom<VanBanPhapLuat>
{
    public string SoHieu { get; set; }

    public DateTime NgayBanHanh { get; set; }

    public int CoQuanBanHanhId { get; set; }

    public int LoaiVanBanId { get; set; }

    public string TrichYeuNoiDung { get; set; }

    public TrangThaiVanBan TrangThai { get; set; }

    public DateTime NgayHieuLuc { get; set; }

    public string DuongDanUrl { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrUpdateCommand, VanBanPhapLuat>();
        profile.CreateMap<GetPagedVanBanPhapLuatQuery, VanBanPhapLuatParameter>();
    }
}