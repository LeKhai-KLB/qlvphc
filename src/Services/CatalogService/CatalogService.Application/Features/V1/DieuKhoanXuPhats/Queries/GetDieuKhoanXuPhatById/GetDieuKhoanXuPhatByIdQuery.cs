using CatalogService.Application.Common.Models.DieuKhoanXuPhats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DieuKhoanXuPhats.Queries.GetDieuKhoanXuPhatById;

public class GetDieuKhoanXuPhatByIdQuery : IRequest<ApiResult<DieuKhoanXuPhatDto>>
{
    public int Id { get; set; }

    public GetDieuKhoanXuPhatByIdQuery(int id)
    {
        Id = id;
    }
}