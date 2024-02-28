using CatalogService.Application.Common.Models.ChiTietLinhVucXuPhats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Queries.GetChiTietLinhVucXuPhatsByTerm;

public class GetChiTietLinhVucXuPhatsByTermQuery : IRequest<ApiResult<IEnumerable<ChiTietLinhVucXuPhatDto>>>
{
    public int LinhVucXuPhatId { get; set; }

    public string? Term { get; set; }

    public GetChiTietLinhVucXuPhatsByTermQuery(int linhVucXuPhatId, string? term)
    {
        LinhVucXuPhatId = linhVucXuPhatId;
        Term = term;
    }
}