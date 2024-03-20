using AutoMapper;
using CatalogService.Application.Common.Models.ToChucs;
using CatalogService.Application.Features.V1.ToChucs.Commands.CreateToChuc;
using CatalogService.Application.Features.V1.ToChucs.Commands.DeleteToChuc;
using CatalogService.Application.Features.V1.ToChucs.Commands.UpdateToChuc;
using CatalogService.Application.Features.V1.ToChucs.Queries.GetAllToChucs;
using CatalogService.Application.Features.V1.ToChucs.Queries.GetToChucById;
using CatalogService.Application.Features.V1.ToChucs.Queries.GetPagedToChuc;
using CatalogService.Application.Parameters.ToChucs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Common.Constants;
using Shared.SeedWord;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CatalogService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize(AuthenticationSchemes = "Bearer")]
public class ToChucController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ToChucController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetPagedToChuc = nameof(GetPagedToChuc);
        public const string GetAllToChucs = nameof(GetAllToChucs);
        public const string GetToChucById = nameof(GetToChucById);
        public const string CreateToChuc = nameof(CreateToChuc);
        public const string UpdateToChuc = nameof(UpdateToChuc);
        public const string DeleteToChuc = nameof(DeleteToChuc);
    }

    [HttpPost("paging", Name = RouteNames.GetPagedToChuc)]
    [ProducesResponseType(typeof(PagedResponse<IEnumerable<ToChucDto>>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.ToChucs.View)]
    public async Task<ActionResult<PagedResponse<IEnumerable<ToChucDto>>>> GetPagedLinhVucXuPhat([FromBody] ToChucParameter request)
    {
        var query = new GetPagedToChucQuery(request);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetAllToChucs)]
    [ProducesResponseType(typeof(IEnumerable<ToChucDto>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.ToChucs.View)]
    public async Task<ActionResult<IEnumerable<ToChucDto>>> GetAllToChucs()
    {
        var query = new GetAllToChucsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetToChucById)]
    [ProducesResponseType(typeof(ToChucDto), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.ToChucs.ViewById)]
    public async Task<ActionResult<ToChucDto>> GetToChucById([FromQuery] int id)
    {
        var query = new GetToChucByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateToChuc)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.ToChucs.Create)]
    public async Task<ActionResult<ApiResult<ToChucDto>>> CreateToChuc([FromBody] CreateToChucDto model)
    {
        var command = _mapper.Map<CreateToChucCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}", Name = RouteNames.UpdateToChuc)]
    [ProducesResponseType(typeof(ApiResult<ToChucDto>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.ToChucs.Edit)]
    public async Task<ActionResult<ApiResult<ToChucDto>>> UpdateToChuc([Required] int id, [FromBody] UpdateToChucCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}", Name = RouteNames.DeleteToChuc)]
    //[Authorize(Permissions.ToChucs.Delete)]
    public async Task<ActionResult<bool>> DeleteToChuc([Required] int id)
    {
        var command = new DeleteToChucCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}