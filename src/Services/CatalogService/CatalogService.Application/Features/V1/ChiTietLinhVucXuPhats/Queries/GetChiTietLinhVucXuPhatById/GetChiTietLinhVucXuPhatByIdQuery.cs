using CatalogService.Application.Common.Models.ChiTietLinhVucXuPhats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Queries.GetChiTietLinhVucXuPhatById;

public class GetChiTietLinhVucXuPhatByIdQuery : IRequest<ApiResult<ChiTietLinhVucXuPhatDto>>
{
    public int Id { get; set; }

    public GetChiTietLinhVucXuPhatByIdQuery(int id)
    {
        Id = id;
    }
}