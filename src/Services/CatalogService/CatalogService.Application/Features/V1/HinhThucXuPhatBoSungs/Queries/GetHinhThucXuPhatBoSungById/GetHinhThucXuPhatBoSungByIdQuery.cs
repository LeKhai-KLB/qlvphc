using CatalogService.Application.Common.Models.HinhThucXuPhatBoSungs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatBoSungs.Queries.GetHinhThucXuPhatBoSungById;
public class GetHinhThucXuPhatBoSungByIdQuery : IRequest<ApiResult<HinhThucXuPhatBoSungDto>>
{
    public int Id { get; set; }

    public GetHinhThucXuPhatBoSungByIdQuery(int id)
    {
        Id = id;
    }
}
