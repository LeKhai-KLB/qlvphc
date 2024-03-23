using CatalogService.Application.Common.Models.KhoBacs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KhoBacs.Queries.GetAllKhoBacs;

public class GetAllKhoBacsQuery : IRequest<ApiResult<IEnumerable<KhoBacDto>>>
{
    public GetAllKhoBacsQuery()
    {
    }
}