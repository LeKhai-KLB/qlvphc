using CatalogService.Application.Common.Models.DieuKhoanXuPhats;
using CatalogService.Application.Parameters.DieuKhoanXuPhats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DieuKhoanXuPhats.Queries.GetDieuKhoanXuPhats;

public class GetDieuKhoanXuPhatsQuery : IRequest<PagedResponse<IEnumerable<DieuKhoanXuPhatDto>>>
{
    public string? SearchTerm { get; set; }
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? OrderBy { get; set; }
    public string? Name { get; set; }
    public bool? IsDeleted { get; set; }

    public GetDieuKhoanXuPhatsQuery(DieuKhoanXuPhatParameter request)
    {
        SearchTerm = request.SearchTerm;
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
        IsDeleted = request.IsDeleted;
    }
}