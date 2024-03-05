using CatalogService.Application.Common.Models.LinhVucXuPhats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LinhVucXuPhats.Queries.GetAllLinhVucXuPhats;

public class GetAllLinhVucXuPhatsQuery : IRequest<ApiResult<IEnumerable<LinhVucXuPhatDto>>>
{
    public GetAllLinhVucXuPhatsQuery()
    {
    }
}