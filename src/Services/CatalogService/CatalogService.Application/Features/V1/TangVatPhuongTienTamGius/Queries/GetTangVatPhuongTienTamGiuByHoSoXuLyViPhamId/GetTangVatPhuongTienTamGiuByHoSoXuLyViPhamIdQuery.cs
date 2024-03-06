
using CatalogService.Application.Common.Models.TangVatPhuongTienTamGius;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.TangVatPhuongTienTamGius.Queries.GetTangVatPhuongTienTamGiuByHoSoXuLyViPhamId;
public class GetTangVatPhuongTienTamGiuByHoSoXuLyViPhamIdQuery : IRequest<ApiResult<IEnumerable<TangVatPhuongTienTamGiuDto>>>
{
    public int Id { get; set; }

    public GetTangVatPhuongTienTamGiuByHoSoXuLyViPhamIdQuery(int id)
    {
        Id = id;
    }
}
