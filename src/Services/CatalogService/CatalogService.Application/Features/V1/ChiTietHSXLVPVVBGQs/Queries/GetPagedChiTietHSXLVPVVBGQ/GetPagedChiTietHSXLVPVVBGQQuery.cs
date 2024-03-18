using CatalogService.Application.Common.Models.ChiTietHSXLVPVVBGQs;
using CatalogService.Application.Parameters.ChiTietHSXLVPVVBGQs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ChiTietHSXLVPVVBGQs.Queries.GetPagedChiTietHSXLVPVVBGQ;

public class GetPagedChiTietHSXLVPVVBGQQuery : IRequest<PagedResponse<IEnumerable<ChiTietHSXLVPVVBGQDto>>>
{
    public string? SearchTerm { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }

    public string? OrderBy { get; set; }

    public GetPagedChiTietHSXLVPVVBGQQuery(ChiTietHSXLVPVVBGQParameter request)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
        SearchTerm = request.SearchTerm;
    }
}