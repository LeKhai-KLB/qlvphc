
using CatalogService.Application.Common.Models.HinhThucXuPhatChinhs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatChinhs.Queries.GetHinhThucXuPhatChinhs
{
    public class GetHinhThucXuPhatChinhsQuery : IRequest<ApiResult<IEnumerable<HinhThucXuPhatChinhDto>>>
    {
        public GetHinhThucXuPhatChinhsQuery()
        {

        }
    }
}