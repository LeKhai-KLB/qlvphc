using CatalogService.Application.Common.Models.VanBanPhapLuats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanPhapLuats.Queries.GetVanBanPhapLuatById;

public class GetVanBanPhapLuatByIdQuery : IRequest<ApiResult<VanBanPhapLuatDto>>
{
    public int Id { get; set; }

    public GetVanBanPhapLuatByIdQuery(int id)
    {
        Id = id;
    }
}