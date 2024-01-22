
using CatalogService.Application.Common.Models.DieuKhoanXuPhats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DieuKhoanXuPhats.Queries.GetDieuKhoanXuPhatsByTerm
{
    public class GetDieuKhoanXuPhatsByTermQuery : IRequest<ApiResult<List<DieuKhoanXuPhatDto>>>
    {
        public string? Term { get; set; }

        public GetDieuKhoanXuPhatsByTermQuery(string? term)
        {
            Term = term;
        }
    }
}