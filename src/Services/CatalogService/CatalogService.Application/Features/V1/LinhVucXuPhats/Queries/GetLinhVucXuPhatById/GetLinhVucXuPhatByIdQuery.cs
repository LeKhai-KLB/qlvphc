using CatalogService.Application.Common.Models.LinhVucXuPhats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LinhVucXuPhats.Queries.GetLinhVucXuPhatById;

public class GetLinhVucXuPhatByIdQuery : IRequest<ApiResult<LinhVucXuPhatDto>>
{
    public int Id { get; set; }

    public GetLinhVucXuPhatByIdQuery(int id)
    {
        Id = id;
    }
}