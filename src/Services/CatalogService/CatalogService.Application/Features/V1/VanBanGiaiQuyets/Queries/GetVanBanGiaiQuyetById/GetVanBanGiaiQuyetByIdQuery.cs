using CatalogService.Application.Common.Models.VanBanGiaiQuyets;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanGiaiQuyets.Queries.GetVanBanGiaiQuyetById;

public class GetVanBanGiaiQuyetByIdQuery : IRequest<ApiResult<VanBanGiaiQuyetDto>>
{
    public int Id { get; set; }

    public GetVanBanGiaiQuyetByIdQuery(int id)
    {
        Id = id;
    }
}