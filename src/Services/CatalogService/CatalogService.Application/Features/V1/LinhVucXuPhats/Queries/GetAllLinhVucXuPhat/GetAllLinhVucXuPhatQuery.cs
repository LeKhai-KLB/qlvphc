using CatalogService.Application.Common.Models.LinhVucXuPhats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LinhVucXuPhats.Queries.GetAllLinhVucXuPhat;

public class GetAllLinhVucXuPhatQuery : IRequest<ApiResult<IEnumerable<LinhVucXuPhatDto>>>
{
    public GetAllLinhVucXuPhatQuery()
    {
    }
}