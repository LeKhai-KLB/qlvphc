using CatalogService.Application.Common.Models.KetQuaXuPhatTruyCuuHSs;
using CatalogService.Application.Parameters.KetQuaXuPhatTruyCuuHSs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Queries.GetPagedKetQuaXuPhatTruyCuuHS;

public class GetPagedKetQuaXuPhatTruyCuuHSQuery : IRequest<PagedResponse<IEnumerable<KetQuaXuPhatTruyCuuHSDto>>>
{
    public string? SearchTerm { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }

    public string? OrderBy { get; set; }

    public GetPagedKetQuaXuPhatTruyCuuHSQuery(KetQuaXuPhatTruyCuuHSParameter request)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
        SearchTerm = request.SearchTerm;
    }
}