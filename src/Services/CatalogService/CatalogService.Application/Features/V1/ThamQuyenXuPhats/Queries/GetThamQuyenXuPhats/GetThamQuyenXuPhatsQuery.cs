using CatalogService.Application.Common.Models.ThamQuyenXuPhats;
using CatalogService.Application.Parameters.ThamQuyenXuPhats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ThamQuyenXuPhats.Queries.GetThamQuyenXuPhats;

public class GetThamQuyenXuPhatsQuery : IRequest<PagedResponse<IEnumerable<ThamQuyenXuPhatDto>>>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? OrderBy { get; set; }
    public string? ThamQuyen { get; set; }
    public bool? IsDeleted { get; set; }
    public GetThamQuyenXuPhatsQuery(ThamQuyenXuPhatParameter request)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
        ThamQuyen = request.ThamQuyen;
        IsDeleted = request.IsDeleted;
    }
}