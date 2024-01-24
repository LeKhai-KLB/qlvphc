using CatalogService.Application.Common.Models.LinhVucXuPhats;
using CatalogService.Application.Parameters.LinhVucXuPhats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LinhVucXuPhats.Queries.GetPagedLinhVucXuPhatAsync;

public class GetPagedLinhVucXuPhatQuery : IRequest<PagedResponse<IEnumerable<LinhVucXuPhatDto>>>
{
    public string? TenLinhVuc { get; set; }

    public string? NhomLinhVuc { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }

    public string? OrderBy { get; set; }

    public GetPagedLinhVucXuPhatQuery(LinhVucXuPhatParameter request)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
        TenLinhVuc = request.TenLinhVuc;
        NhomLinhVuc = request.NhomLinhVuc;
    }
}