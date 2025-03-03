using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using CatalogService.Application.Parameters.HoSoXuLyViPhams;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Queries.GetPagedVanBanByHSVPId;

public class GetPagedVanBanByHSVPIdQuery : IRequest<PagedResponse<IEnumerable<HoSoXuLyViPham_VanBanGiaiQuyetDto>>>
{
    public string? SearchTerm { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }

    public string? OrderBy { get; set; }

    public int HoSoXuLyViPhamId { get; set; }

    public GetPagedVanBanByHSVPIdQuery(HSVPVanBanGiaiQuyetParameter request)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
        SearchTerm = request.SearchTerm;
        HoSoXuLyViPhamId = request.HoSoXuLyViPhamId;
    }
}