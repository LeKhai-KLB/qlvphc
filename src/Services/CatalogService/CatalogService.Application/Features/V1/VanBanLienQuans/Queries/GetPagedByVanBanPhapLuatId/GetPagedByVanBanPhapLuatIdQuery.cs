using CatalogService.Application.Common.Models.VanBanLienQuans;
using CatalogService.Application.Parameters.VanBanLienQuans;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanLienQuans.Queries.GetPagedByVanBanPhapLuatId;

public class GetPagedByVanBanPhapLuatIdQuery : IRequest<ApiResult<IEnumerable<VanBanLienQuanDto>>>
{
    public int? VanBanPhapLuatId { get; set; }

    public string? SearchTerm { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }

    public string? OrderBy { get; set; }

    public GetPagedByVanBanPhapLuatIdQuery(VanBanLienQuanParameter request)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
        VanBanPhapLuatId = request.VanBanPhapLuatId;
        SearchTerm = request.SearchTerm;
    }
}