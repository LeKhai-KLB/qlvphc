using CatalogService.Application.Common.Models.KetQuaXuPhatTruyCuuHSs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Queries.GetKetQuaXuPhatTruyCuuHSById;

public class GetKetQuaXuPhatTruyCuuHSByIdQuery : IRequest<ApiResult<KetQuaXuPhatTruyCuuHSDto>>
{
    public int Id { get; set; }

    public GetKetQuaXuPhatTruyCuuHSByIdQuery(int id)
    {
        Id = id;
    }
}