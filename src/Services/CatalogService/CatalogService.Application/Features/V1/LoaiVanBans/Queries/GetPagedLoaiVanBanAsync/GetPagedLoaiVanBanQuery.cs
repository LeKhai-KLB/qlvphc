using CatalogService.Application.Common.Models.LoaiVanBans;
using CatalogService.Application.Parameters.LoaiVanBans;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LoaiVanBans.Queries.GetPagedLoaiVanBanAsync;

public class GetPagedLoaiVanBanQuery : IRequest<PagedResponse<IEnumerable<LoaiVanBanDto>>>
{
    public string? SearchTerm { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }

    public string? OrderBy { get; set; }

    public GetPagedLoaiVanBanQuery(LoaiVanBanParameter request)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
        SearchTerm = request.SearchTerm;
    }
}