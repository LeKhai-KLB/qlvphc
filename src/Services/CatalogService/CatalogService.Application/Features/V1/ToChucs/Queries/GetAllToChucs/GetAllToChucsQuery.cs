using CatalogService.Application.Common.Models.ToChucs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ToChucs.Queries.GetAllToChucs;

public class GetAllToChucsQuery : IRequest<ApiResult<IEnumerable<ToChucDropdownDto>>>
{
    public GetAllToChucsQuery()
    {
    }
}