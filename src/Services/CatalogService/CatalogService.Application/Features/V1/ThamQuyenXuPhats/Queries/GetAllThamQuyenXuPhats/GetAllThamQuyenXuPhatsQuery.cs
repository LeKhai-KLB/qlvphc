using CatalogService.Application.Common.Models.ThamQuyenXuPhats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ThamQuyenXuPhats.Queries.GetAllThamQuyenXuPhats;

public class GetAllThamQuyenXuPhatsQuery : IRequest<ApiResult<IEnumerable<ThamQuyenXuPhatDto>>>
{
    public GetAllThamQuyenXuPhatsQuery()
    {
    }
}