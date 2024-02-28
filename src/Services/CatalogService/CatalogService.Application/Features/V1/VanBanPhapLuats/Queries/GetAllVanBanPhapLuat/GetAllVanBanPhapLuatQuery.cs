using CatalogService.Application.Common.Models.VanBanPhapLuats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanPhapLuats.Queries.GetAllVanBanPhapLuat;

public class GetAllVanBanPhapLuatQuery : IRequest<ApiResult<IEnumerable<VanBanPhapLuatDto>>>
{
    public bool? IsFilterTrichYeu {  get; set; }

    public GetAllVanBanPhapLuatQuery(bool? isFilterTrichYeu)
    {
        IsFilterTrichYeu = isFilterTrichYeu;
    }
}