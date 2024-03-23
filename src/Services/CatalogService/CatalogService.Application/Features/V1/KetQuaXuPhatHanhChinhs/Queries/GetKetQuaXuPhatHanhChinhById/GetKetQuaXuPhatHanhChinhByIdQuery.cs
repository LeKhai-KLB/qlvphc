using CatalogService.Application.Common.Models.KetQuaXuPhatHanhChinhs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Queries.GetKetQuaXuPhatHanhChinhById;

public class GetKetQuaXuPhatHanhChinhByIdQuery : IRequest<ApiResult<KetQuaXuPhatHanhChinhDto>>
{
    public int Id { get; set; }

    public GetKetQuaXuPhatHanhChinhByIdQuery(int id)
    {
        Id = id;
    }
}