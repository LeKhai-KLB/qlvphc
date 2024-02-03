using CatalogService.Application.Common.Models.VanBanGiaiQuyets;
using CatalogService.Application.Parameters.VanBanGiaiQuyets;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanGiaiQuyets.Queries.GetPagedVanBanGiaiQuyetAsync;

public class GetPagedVanBanGiaiQuyetQuery : IRequest<PagedResponse<IEnumerable<VanBanGiaiQuyetDto>>>
{
    public string? MaGiayTo { get; set; }

    public string? TheoNghiDinh { get; set; }

    public string? TenGiayTo { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }

    public string? OrderBy { get; set; }

    public string? SearchTerm { get; set; }

    public GetPagedVanBanGiaiQuyetQuery(VanBanGiaiQuyetParameter request)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
        MaGiayTo = request.MaGiayTo;
        TheoNghiDinh = request.TheoNghiDinh;
        TenGiayTo = request.TenGiayTo;
        SearchTerm = request.SearchTerm;
    }
}