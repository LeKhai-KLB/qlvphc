using CatalogService.Application.Common.Models.LoaiVanBans;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LoaiVanBans.Queries.GetLoaiVanBansByTerm;

public class GetLoaiVanBansByTermQuery : IRequest<ApiResult<IEnumerable<LoaiVanBanDto>>>
{
    public string? Term { get; set; }

    public GetLoaiVanBansByTermQuery(string? term)
    {
        Term = term;
    }
}