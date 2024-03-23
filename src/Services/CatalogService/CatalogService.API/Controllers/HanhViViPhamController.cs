using System.ComponentModel.DataAnnotations;
using System.Net;
using AutoMapper;
using CatalogService.Application.Common.Models.HanhViViPhams;
using CatalogService.Application.Features.V1.HanhViViPhams.Commands.CreateHanhViViPham;
using CatalogService.Application.Features.V1.HanhViViPhams.Commands.DeleteHanhViViPham;
using CatalogService.Application.Features.V1.HanhViViPhams.Commands.UpdateHanhViViPham;
using CatalogService.Application.Features.V1.HanhViViPhams.Queries.GetHanhViViPhamById;
using CatalogService.Application.Parameters.HanhViViPhams;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.SeedWord;
using CatalogService.Application.Features.V1.HanhViViPhams.Queries.GetPagedHanhViViPham;
using Microsoft.AspNetCore.Authorization;
using Shared.Common.Constants;
using CatalogService.Application.Features.V1.HanhViViPhams.Commands.ImportHVVPFromQD;

namespace CatalogService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize(AuthenticationSchemes = "Bearer")]
public class HanhViViPhamController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public HanhViViPhamController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetPagedHanhViViPham = nameof(GetPagedHanhViViPham);
        public const string CreateHanhViViPham = nameof(CreateHanhViViPham);
        public const string UpdateHanhViViPham = nameof(UpdateHanhViViPham);
        public const string DeleteHanhViViPham = nameof(DeleteHanhViViPham);
        public const string GetHanhViViPhamById = nameof(GetHanhViViPhamById);
        public const string ImportHVVPFromQD = nameof(ImportHVVPFromQD);
    }

    [HttpPost("paging", Name = RouteNames.GetPagedHanhViViPham)]
    [ProducesResponseType(typeof(PagedResponse<IEnumerable<HanhViViPhamDto>>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.HanhViViPhams.View)]
    public async Task<ActionResult<PagedResponse<IEnumerable<HanhViViPhamDto>>>> GetPagedHanhViViPham([FromBody] HanhViViPhamParameter request)
    {
        var query = new GetPagedHanhViViPhamQuery(request);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id:int}", Name = RouteNames.GetHanhViViPhamById)]
    [ProducesResponseType(typeof(HanhViViPhamDto), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.HanhViViPhams.ViewById)]
    public async Task<ActionResult<HanhViViPhamDto>> GetHanhViViPhamById([Required] int id)
    {
        var query = new GetHanhViViPhamByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateHanhViViPham)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.HanhViViPhams.Create)]
    public async Task<ActionResult<ApiResult<HanhViViPhamDto>>> CreateHanhViViPham([FromBody] CreateHanhViViPhamDto model)
    {
        var command = _mapper.Map<CreateHanhViViPhamCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}", Name = RouteNames.UpdateHanhViViPham)]
    [ProducesResponseType(typeof(ApiResult<HanhViViPhamDto>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.HanhViViPhams.Edit)]
    public async Task<ActionResult<ApiResult<HanhViViPhamDto>>> UpdateHanhViViPham([Required] int id, [FromBody] UpdateHanhViViPhamCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}", Name = RouteNames.DeleteHanhViViPham)]
    //[Authorize(Permissions.HanhViViPhams.Delete)]
    public async Task<ActionResult<bool>> DeleteHanhViViPham([Required] int id)
    {
        var command = new DeleteHanhViViPhamCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{hoSoXuLyViPhamId:int}", Name = RouteNames.ImportHVVPFromQD)]
    //[Authorize(Permissions.HanhViViPhams.Edit)]
    public async Task<ActionResult<bool>> ImportHVVPFromQD([Required] int hoSoXuLyViPhamId)
    {
        var command = new ImportHVVPFromQDCommand(hoSoXuLyViPhamId);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}