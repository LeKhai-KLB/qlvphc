using CatalogService.Application.Common.Models.CongDans;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CongDans.Queries.GetCongDanById;

public class GetCongDanByIdQuery : IRequest<ApiResult<CongDanDto>>
{
    public int Id { get; set; }

    public GetCongDanByIdQuery(int id)
    {
        Id = id;
    }
}