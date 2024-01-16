
using CatalogService.Application.Common.Models.TinhThanhPhos;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.TinhThanhPhos.Queries.GetTinhThanhPhosByTerm
{
    public class GetTinhThanhPhosByTermQuery : IRequest<ApiResult<List<TinhThanhPhoDto>>>
    {
        public string? Term { get; set; }

        public GetTinhThanhPhosByTermQuery(string? term)
        {
            Term = term;
        }
    }
}