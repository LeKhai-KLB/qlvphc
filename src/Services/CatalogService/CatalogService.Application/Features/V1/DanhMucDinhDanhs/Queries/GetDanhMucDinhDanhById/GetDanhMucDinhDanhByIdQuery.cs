using CatalogService.Application.Common.Models.DanhMucDinhDanhs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DanhMucDinhDanhs.Queries.GetDanhMucDinhDanhById;
public class GetDanhMucDinhDanhByIdQuery : IRequest<ApiResult<DanhMucDinhDanhDto>>
{
    public int Id { get; set; }

    public GetDanhMucDinhDanhByIdQuery(int id)
    {
        Id = id;
    }
}
