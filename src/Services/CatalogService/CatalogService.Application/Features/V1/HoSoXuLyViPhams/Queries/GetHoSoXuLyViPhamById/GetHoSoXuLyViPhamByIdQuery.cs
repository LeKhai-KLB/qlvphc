using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HoSoXuLyViPhams.Queries.GetHoSoXuLyViPhamById;

public class GetHoSoXuLyViPhamByIdQuery : IRequest<ApiResult<HoSoXuLyViPhamDto>>
{
    public int Id { get; set; }

    public GetHoSoXuLyViPhamByIdQuery(int id)
    {
        Id = id;
    }
}