using System.ComponentModel.DataAnnotations;
using System.Net;
using AutoMapper;
using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using CatalogService.Application.Features.V1.HoSoXuLyViPhams.Commands.CreateHoSoXuLyViPham;
using CatalogService.Application.Features.V1.HoSoXuLyViPhams.Commands.DeleteHoSoXuLyViPham;
using CatalogService.Application.Features.V1.HoSoXuLyViPhams.Commands.UpdateHoSoXuLyViPham;
using CatalogService.Application.Features.V1.HoSoXuLyViPhams.Queries.GetHoSoXuLyViPhamById;
using CatalogService.Application.Parameters.HoSoXuLyViPhams;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.SeedWord;
using CatalogService.Application.Features.V1.HoSoXuLyViPhams.Queries.GetPagedHoSoXuLyViPham;
using Microsoft.AspNetCore.Authorization;
using Shared.Common.Constants;

namespace CatalogService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HoSoXuLyViPhamController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public HoSoXuLyViPhamController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetPagedHoSoXuLyViPham = nameof(GetPagedHoSoXuLyViPham);
        public const string CreateHoSoXuLyViPham = nameof(CreateHoSoXuLyViPham);
        public const string UpdateHoSoXuLyViPham = nameof(UpdateHoSoXuLyViPham);
        public const string DeleteHoSoXuLyViPham = nameof(DeleteHoSoXuLyViPham);
        public const string GetHoSoXuLyViPhamById = nameof(GetHoSoXuLyViPhamById);
    }

    [HttpPost("paging", Name = RouteNames.GetPagedHoSoXuLyViPham)]
    [ProducesResponseType(typeof(PagedResponse<IEnumerable<HoSoXuLyViPhamDto>>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.HoSoXuLyViPhams.View)]
    public async Task<ActionResult<PagedResponse<IEnumerable<HoSoXuLyViPhamDto>>>> GetHoSoXuLyViPhams([FromBody] HoSoXuLyViPhamParameter request)
    {
        var query = new GetPagedHoSoXuLyViPhamQuery(request);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id:int}", Name = RouteNames.GetHoSoXuLyViPhamById)]
    [ProducesResponseType(typeof(HoSoXuLyViPhamDto), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.HoSoXuLyViPhams.ViewById)]
    public async Task<ActionResult<HoSoXuLyViPhamDto>> GetHoSoXuLyViPhamById([Required] int id)
    {
        var query = new GetHoSoXuLyViPhamByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateHoSoXuLyViPham)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.HoSoXuLyViPhams.Create)]
    public async Task<ActionResult<ApiResult<HoSoXuLyViPhamDto>>> CreateHoSoXuLyViPham([FromBody] CreateHoSoXuLyViPhamDto model)
    {
        var command = _mapper.Map<CreateHoSoXuLyViPhamCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}", Name = RouteNames.UpdateHoSoXuLyViPham)]
    [ProducesResponseType(typeof(ApiResult<HoSoXuLyViPhamDto>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.HoSoXuLyViPhams.Edit)]
    public async Task<ActionResult<ApiResult<HoSoXuLyViPhamDto>>> UpdateHoSoXuLyViPham([Required] int id, [FromBody] UpdateHoSoXuLyViPhamCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}", Name = RouteNames.DeleteHoSoXuLyViPham)]
    [Authorize(Permissions.HoSoXuLyViPhams.Delete)]
    public async Task<ActionResult<bool>> DeleteHoSoXuLyViPham([Required] int id)
    {
        var command = new DeleteHoSoXuLyViPhamCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}