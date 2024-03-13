using AutoMapper;
using CatalogService.Application.Common.Models.CongDans;
using CatalogService.Application.Features.V1.CongDans.Commands.CreateCongDan;
using CatalogService.Application.Features.V1.CongDans.Commands.DeleteCongDan;
using CatalogService.Application.Features.V1.CongDans.Commands.UpdateCongDan;
using CatalogService.Application.Features.V1.CongDans.Queries.GetAllCongDans;
using CatalogService.Application.Features.V1.CongDans.Queries.GetCongDanById;
using CatalogService.Application.Features.V1.CongDans.Queries.GetPagedCongDan;
using CatalogService.Application.Parameters.CongDans;
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
[Authorize(AuthenticationSchemes = "Bearer")]
public class CongDanController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CongDanController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetPagedCongDan = nameof(GetPagedCongDan);
        public const string GetAllCongDans = nameof(GetAllCongDans);
        public const string GetCongDanById = nameof(GetCongDanById);
        public const string CreateCongDan = nameof(CreateCongDan);
        public const string UpdateCongDan = nameof(UpdateCongDan);
        public const string DeleteCongDan = nameof(DeleteCongDan);
    }

    [HttpPost("paging", Name = RouteNames.GetPagedCongDan)]
    [ProducesResponseType(typeof(PagedResponse<IEnumerable<CongDanDto>>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.CongDans.View)]
    public async Task<ActionResult<PagedResponse<IEnumerable<CongDanDto>>>> GetPagedLinhVucXuPhat([FromBody] CongDanParameter request)
    {
        var query = new GetPagedCongDanQuery(request);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetAllCongDans)]
    [ProducesResponseType(typeof(IEnumerable<CongDanDto>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.CongDans.View)]
    public async Task<ActionResult<IEnumerable<CongDanDto>>> GetAllCongDans()
    {
        var query = new GetAllCongDansQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetCongDanById)]
    [ProducesResponseType(typeof(CongDanDto), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.CongDans.ViewById)]
    public async Task<ActionResult<CongDanDto>> GetCongDanById([FromQuery] int id)
    {
        var query = new GetCongDanByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateCongDan)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.CongDans.Create)]
    public async Task<ActionResult<ApiResult<CongDanDto>>> CreateCongDan([FromBody] CreateCongDanDto model)
    {
        var command = _mapper.Map<CreateCongDanCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}", Name = RouteNames.UpdateCongDan)]
    [ProducesResponseType(typeof(ApiResult<CongDanDto>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.CongDans.Edit)]
    public async Task<ActionResult<ApiResult<CongDanDto>>> UpdateCongDan([Required] int id, [FromBody] UpdateCongDanCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}", Name = RouteNames.DeleteCongDan)]
    [Authorize(Permissions.CongDans.Delete)]
    public async Task<ActionResult<bool>> DeleteCongDan([Required] int id)
    {
        var command = new DeleteCongDanCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}