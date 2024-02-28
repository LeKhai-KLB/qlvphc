using CatalogService.Application.Common.Models.CoQuanBanHanhs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CoQuanBanHanhs.Queries.GetCoQuanBanHanhsByTerm;

public class GetCoQuanBanHanhsByTermQuery : IRequest<ApiResult<IEnumerable<CoQuanBanHanhDto>>>
{
    public string? Term { get; set; }

    public GetCoQuanBanHanhsByTermQuery(string? term)
    {
        Term = term;
    }
}