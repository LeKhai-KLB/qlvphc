
using CatalogService.Application.Common.Models.QuyetDinhXuPhats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.QuyetDinhXuPhats.Queries.GetQuyetDinhXuPhatByHoSoXuLyViPhamId;
public class GetQuyetDinhXuPhatByHoSoXuLyViPhamIdQuery : IRequest<ApiResult<IEnumerable<QuyetDinhXuPhatDto>>>
{
    public int Id { get; set; }

    public GetQuyetDinhXuPhatByHoSoXuLyViPhamIdQuery(int id)
    {
        Id = id;
    }
}
