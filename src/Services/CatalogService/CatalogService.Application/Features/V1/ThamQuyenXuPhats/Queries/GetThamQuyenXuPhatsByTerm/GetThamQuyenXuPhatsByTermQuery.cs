using CatalogService.Application.Common.Models.ThamQuyenXuPhats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ThamQuyenXuPhats.Queries.GetThamQuyenXuPhatsByTerm;

public class GetThamQuyenXuPhatsByTermQuery : IRequest<ApiResult<List<ThamQuyenXuPhatDto>>>
{
    public string? Term { get; set; }

    public GetThamQuyenXuPhatsByTermQuery(string? term)
    {
        Term = term;
    }
}