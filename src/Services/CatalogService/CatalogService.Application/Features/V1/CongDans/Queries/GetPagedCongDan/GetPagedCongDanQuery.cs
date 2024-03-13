using CatalogService.Application.Common.Models.CongDans;
using CatalogService.Application.Parameters.CongDans;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CongDans.Queries.GetPagedCongDan;

public class GetPagedCongDanQuery : IRequest<PagedResponse<IEnumerable<CongDanDto>>>
{
    public string? SearchTerm { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }

    public string? OrderBy { get; set; }

    public GetPagedCongDanQuery(CongDanParameter request)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
        SearchTerm = request.SearchTerm;
    }
}