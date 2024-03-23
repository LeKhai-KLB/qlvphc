using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Queries.GetPagedKetQuaXuPhatTruyCuuHS;
using CatalogService.Application.Parameters.KetQuaXuPhatTruyCuuHSs;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Common;

public class CreateOrUpdateCommand : IMapFrom<KetQuaXuPhatTruyCuuHS>
{
    public int HoSoXuLyViPhamId { get; set; }

    public DateTime NgayThiHanh { get; set; }

    public DateTime ThoiHanThiHanh { get; set; }

    public string? NoiDung { get; set; }

    public int CoQuanBanHanhId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrUpdateCommand, KetQuaXuPhatTruyCuuHS>();
        profile.CreateMap<GetPagedKetQuaXuPhatTruyCuuHSQuery, KetQuaXuPhatTruyCuuHSParameter>();
    }
}