using CatalogService.Application.Common.Models.CongDans;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CongDans.Queries.GetAllCongDans;

public class GetAllCongDansQuery : IRequest<ApiResult<IEnumerable<CongDanDropDownDto>>>
{
    public GetAllCongDansQuery()
    {
    }
}