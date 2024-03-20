using CatalogService.Application.Common.Models.ToChucs;
using CatalogService.Application.Parameters.ToChucs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ToChucs.Queries.GetPagedToChuc;

public class GetPagedToChucQuery : IRequest<PagedResponse<IEnumerable<ToChucDto>>>
{
    public string? SearchTerm { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }

    public string? OrderBy { get; set; }

    public GetPagedToChucQuery(ToChucParameter request)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
        SearchTerm = request.SearchTerm;
    }
}