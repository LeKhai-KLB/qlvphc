using CatalogService.Application.Common.Models.ThamQuyenXuPhats;
using CatalogService.Application.Parameters.ThamQuyenXuPhats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ThamQuyenXuPhats.Queries.GetPageThamQuyenXuPhat;

public class GetPageThamQuyenXuPhatQuery : IRequest<PagedResponse<IEnumerable<ThamQuyenXuPhatDto>>>
{
    public int? DieuKhoanXuPhatId { get; set; }
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? OrderBy { get; set; }
    public string? SearchTerm { get; set; }
    public bool? IsDeleted { get; set; }

    public GetPageThamQuyenXuPhatQuery(ThamQuyenXuPhatParameter request)
    {
        DieuKhoanXuPhatId = request.DieuKhoanXuPhatId;
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
        SearchTerm = request.SearchTerm;
        IsDeleted = request.IsDeleted;
    }
}