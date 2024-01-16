
using CatalogService.Application.Common.Models.QuanHuyens;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.QuanHuyens.Queries.GetQuanHuyenByTinhThanhPhoId;
public class GetQuanHuyenByTinhThanhPhoIdQuery : IRequest<ApiResult<IEnumerable<QuanHuyenDto>>>
{
    public int Id { get; set; }

    public GetQuanHuyenByTinhThanhPhoIdQuery(int id)
    {
        Id = id;
    }
}
