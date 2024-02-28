using CatalogService.Application.Common.Models.LinhVucXuPhats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LinhVucXuPhats.Queries.GetLinhVucXuPhatsByTerm;

public class GetLinhVucXuPhatsByTermQuery : IRequest<ApiResult<IEnumerable<LinhVucXuPhatDto>>>
{
    public string? Term { get; set; }

    public GetLinhVucXuPhatsByTermQuery(string? term)
    {
        Term = term;
    }
}