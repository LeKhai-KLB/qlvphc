using CatalogService.Application.Common.Models.KhoBacs;
using CatalogService.Application.Parameters.KhoBacs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KhoBacs.Queries.GetPagedKhoBac;

public class GetPagedKhoBacQuery : IRequest<PagedResponse<IEnumerable<KhoBacDto>>>
{
    public string? SearchTerm { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }

    public string? OrderBy { get; set; }

    public GetPagedKhoBacQuery(KhoBacParameter request)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
        SearchTerm = request.SearchTerm;
    }
}