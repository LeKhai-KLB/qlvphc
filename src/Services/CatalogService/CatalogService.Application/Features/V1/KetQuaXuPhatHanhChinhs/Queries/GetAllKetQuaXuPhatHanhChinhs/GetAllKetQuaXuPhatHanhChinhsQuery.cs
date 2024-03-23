using CatalogService.Application.Common.Models.KetQuaXuPhatHanhChinhs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Queries.GetAllKetQuaXuPhatHanhChinhs;

public class GetAllKetQuaXuPhatHanhChinhsQuery : IRequest<ApiResult<IEnumerable<KetQuaXuPhatHanhChinhDto>>>
{
    public GetAllKetQuaXuPhatHanhChinhsQuery()
    {
    }
}