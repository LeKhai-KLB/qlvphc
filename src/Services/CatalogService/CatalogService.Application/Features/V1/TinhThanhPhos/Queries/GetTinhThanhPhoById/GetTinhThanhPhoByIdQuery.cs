using CatalogService.Application.Common.Models.TinhThanhPhos;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.TinhThanhPhos.Queries.GetTinhThanhPhoById;
public class GetTinhThanhPhoByIdQuery : IRequest<ApiResult<TinhThanhPhoDto>>
{
    public int Id { get; set; }

    public GetTinhThanhPhoByIdQuery(int id)
    {
        Id = id;
    }
}
