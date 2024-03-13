using CatalogService.Application.Common.Models.DieuKhoanBoSungKhacPhucs;
using CatalogService.Application.Parameters.DieuKhoanBoSungKhacPhucs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Queries.GetPagedDieuKhoanBoSungKhacPhuc;

public class GetPagedDieuKhoanBoSungKhacPhucQuery : IRequest<PagedResponse<IEnumerable<DieuKhoanBoSungKhacPhucDto>>>
{
    public int DieuKhoanXuPhatId { get; set; }
    public string? SearchTerm { get; set; }
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? OrderBy { get; set; }

    public GetPagedDieuKhoanBoSungKhacPhucQuery(DieuKhoanBoSungKhacPhucParameter request)
    {
        DieuKhoanXuPhatId = request.DieuKhoanXuPhatId;
        SearchTerm = request.SearchTerm;
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
    }
}