using CatalogService.Application.Common.Models.ThamQuyenXuPhats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ThamQuyenXuPhats.Queries.GetThamQuyenXuPhatById;

public class GetThamQuyenXuPhatByIdQuery : IRequest<ApiResult<ThamQuyenXuPhatDto>>
{
    public int Id { get; set; }

    public GetThamQuyenXuPhatByIdQuery(int id)
    {
        Id = id;
    }
}