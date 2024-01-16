using CatalogService.Application.Common.Models.ChiTietLinhVucXuPhats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Queries.GetChiTietByLinhVucXuPhatId;

public class GetChiTietByLinhVucXuPhatIdQuery : IRequest<ApiResult<IEnumerable<ChiTietLinhVucXuPhatDto>>>
{
    public int LinhVucXuPhatId { get; set; }

    public GetChiTietByLinhVucXuPhatIdQuery(int linhVucXuPhatId)
    {
        LinhVucXuPhatId = linhVucXuPhatId;
    }
}