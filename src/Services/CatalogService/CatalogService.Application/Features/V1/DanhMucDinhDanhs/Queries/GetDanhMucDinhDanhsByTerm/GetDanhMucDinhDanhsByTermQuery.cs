
using CatalogService.Application.Common.Models.DanhMucDinhDanhs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DanhMucDinhDanhs.Queries.GetDanhMucDinhDanhsByTerm
{
    public class GetDanhMucDinhDanhsByTermQuery : IRequest<ApiResult<List<DanhMucDinhDanhDto>>>
    {
        public string? Term { get; set; }

        public GetDanhMucDinhDanhsByTermQuery(string? term)
        {
            Term = term;
        }
    }
}