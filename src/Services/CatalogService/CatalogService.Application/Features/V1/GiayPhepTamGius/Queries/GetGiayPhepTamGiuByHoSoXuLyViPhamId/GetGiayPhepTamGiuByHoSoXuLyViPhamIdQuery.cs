
using CatalogService.Application.Common.Models.GiayPhepTamGius;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.GiayPhepTamGius.Queries.GetGiayPhepTamGiuByHoSoXuLyViPhamId;
public class GetGiayPhepTamGiuByHoSoXuLyViPhamIdQuery : IRequest<ApiResult<IEnumerable<GiayPhepTamGiuDto>>>
{
    public int Id { get; set; }

    public GetGiayPhepTamGiuByHoSoXuLyViPhamIdQuery(int id)
    {
        Id = id;
    }
}
