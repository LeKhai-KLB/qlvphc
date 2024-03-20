using CatalogService.Application.Common.Models.ToChucs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ToChucs.Queries.GetToChucById;

public class GetToChucByIdQuery : IRequest<ApiResult<ToChucDto>>
{
    public int Id { get; set; }

    public GetToChucByIdQuery(int id)
    {
        Id = id;
    }
}