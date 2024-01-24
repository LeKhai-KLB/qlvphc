using CatalogService.Application.Common.Models.CoQuanBanHanhs;
using CatalogService.Application.Parameters.CoQuanBanHanhs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CoQuanBanHanhs.Queries.GetPagedCoQuanBanHanhAsync;

public class GetPagedCoQuanBanHanhQuery : IRequest<PagedResponse<IEnumerable<CoQuanBanHanhDto>>>
{
    public string? NhomCoQuan { get; set; }

    public string? TenCoQuan { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }

    public string? OrderBy { get; set; }

    public GetPagedCoQuanBanHanhQuery(CoQuanBanHanhParameter request)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
        NhomCoQuan = request.NhomCoQuan;
        TenCoQuan = request.TenCoQuan;
    }
}