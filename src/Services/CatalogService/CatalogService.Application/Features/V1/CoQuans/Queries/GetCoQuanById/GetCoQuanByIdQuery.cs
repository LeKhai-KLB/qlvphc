using CatalogService.Application.Common.Models.CoQuans;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CoQuans.Queries.GetCoQuanById;

public class GetCoQuanByIdQuery : IRequest<ApiResult<CoQuanDto>>
{
    public int Id { get; set; }

    public GetCoQuanByIdQuery(int id)
    {
        Id = id;
    }
}