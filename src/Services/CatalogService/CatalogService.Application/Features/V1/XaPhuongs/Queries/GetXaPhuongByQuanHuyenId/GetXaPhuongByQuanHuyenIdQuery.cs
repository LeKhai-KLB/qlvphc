using CatalogService.Application.Common.Models.XaPhuongs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.XaPhuongs.Queries.GetXaPhuongByQuanHuyenId;
public class GetXaPhuongByQuanHuyenIdQuery : IRequest<ApiResult<IEnumerable<XaPhuongDto>>>
{
    public int Id { get; set; }

    public GetXaPhuongByQuanHuyenIdQuery(int id)
    {
        Id = id;
    }
}
