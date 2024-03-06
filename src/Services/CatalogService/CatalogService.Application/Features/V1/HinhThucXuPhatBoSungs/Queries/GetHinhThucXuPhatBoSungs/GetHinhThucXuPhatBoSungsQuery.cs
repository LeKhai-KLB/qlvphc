
using CatalogService.Application.Common.Models.HinhThucXuPhatBoSungs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatBoSungs.Queries.GetHinhThucXuPhatBoSungs
{
    public class GetHinhThucXuPhatBoSungsQuery : IRequest<ApiResult<IEnumerable<HinhThucXuPhatBoSungDto>>>
    {
        public GetHinhThucXuPhatBoSungsQuery()
        {

        }
    }
}