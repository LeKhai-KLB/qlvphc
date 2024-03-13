using CatalogService.Application.Common.Models.CoQuans;
using CatalogService.Application.Parameters.CoQuans;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CoQuans.Queries.GetPagedCoQuan;

public class GetPagedCoQuanQuery : IRequest<PagedResponse<IEnumerable<CoQuanDto>>>
{
    public string? SearchTerm { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }

    public string? OrderBy { get; set; }

    public GetPagedCoQuanQuery(CoQuanParameter request)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
        SearchTerm = request.SearchTerm;
    }
}