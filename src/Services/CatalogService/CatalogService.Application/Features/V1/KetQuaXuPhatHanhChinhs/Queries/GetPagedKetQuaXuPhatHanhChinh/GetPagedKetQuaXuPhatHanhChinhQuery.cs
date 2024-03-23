using CatalogService.Application.Common.Models.KetQuaXuPhatHanhChinhs;
using CatalogService.Application.Parameters.KetQuaXuPhatHanhChinhs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Queries.GetPagedKetQuaXuPhatHanhChinh;

public class GetPagedKetQuaXuPhatHanhChinhQuery : IRequest<PagedResponse<IEnumerable<KetQuaXuPhatHanhChinhDto>>>
{
    public string? SearchTerm { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }

    public string? OrderBy { get; set; }

    public GetPagedKetQuaXuPhatHanhChinhQuery(KetQuaXuPhatHanhChinhParameter request)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
        SearchTerm = request.SearchTerm;
    }
}