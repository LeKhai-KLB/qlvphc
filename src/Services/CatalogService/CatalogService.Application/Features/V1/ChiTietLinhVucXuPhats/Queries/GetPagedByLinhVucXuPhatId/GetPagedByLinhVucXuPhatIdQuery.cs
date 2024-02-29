using CatalogService.Application.Common.Models.ChiTietLinhVucXuPhats;
using CatalogService.Application.Parameters.ChiTietLinhVucXuPhats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Queries.GetPagedByLinhVucXuPhatId;

public class GetPagedByLinhVucXuPhatIdQuery : IRequest<ApiResult<IEnumerable<ChiTietLinhVucXuPhatDto>>>
{
    public int? LinhVucXuPhatId { get; set; }

    public string? SearchTerm { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }

    public string? OrderBy { get; set; }

    public GetPagedByLinhVucXuPhatIdQuery(ChiTietLinhVucXuPhatParameter request)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
        LinhVucXuPhatId = request.LinhVucXuPhatId;
        SearchTerm = request.SearchTerm;
    }
}