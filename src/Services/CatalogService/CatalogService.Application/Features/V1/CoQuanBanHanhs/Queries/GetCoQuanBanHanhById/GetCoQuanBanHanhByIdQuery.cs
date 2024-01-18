using CatalogService.Application.Common.Models.CoQuanBanHanhs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CoQuanBanHanhs.Queries.GetCoQuanBanHanhById;

public class GetCoQuanBanHanhByIdQuery : IRequest<ApiResult<CoQuanBanHanhDto>>
{
    public int Id { get; set; }

    public GetCoQuanBanHanhByIdQuery(int id)
    {
        Id = id;
    }
}