using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using CatalogService.Application.Parameters.HoSoXuLyViPhams;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HoSoXuLyViPhams.Queries.GetPagedHoSoXuLyViPham;

public class GetPagedHoSoXuLyViPhamQuery : IRequest<PagedResponse<IEnumerable<HoSoXuLyViPhamDto>>>
{
    public string? SearchTerm { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }

    public string? OrderBy { get; set; }

    public GetPagedHoSoXuLyViPhamQuery(HoSoXuLyViPhamParameter request)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
        SearchTerm = request.SearchTerm;
    }
}