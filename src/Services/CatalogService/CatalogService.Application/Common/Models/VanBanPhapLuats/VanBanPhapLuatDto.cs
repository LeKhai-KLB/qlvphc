using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Constants;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Common.Models.VanBanPhapLuats;

public class VanBanPhapLuatDto : IMapFrom<VanBanPhapLuat>
{
    public int Id { get; set; }

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
        profile.CreateMap<VanBanPhapLuat, VanBanPhapLuatDto>().ReverseMap();
    }
}