using AutoMapper;
using CatalogService.Application.Common.Models.CoQuans;
using CatalogService.Application.Features.V1.CoQuans.Commands.CreateCoQuan;
using CatalogService.Application.Features.V1.CoQuans.Commands.DeleteCoQuan;
using CatalogService.Application.Features.V1.CoQuans.Commands.UpdateCoQuan;
using CatalogService.Application.Features.V1.CoQuans.Queries.GetAllCoQuans;
using CatalogService.Application.Features.V1.CoQuans.Queries.GetCoQuanById;
using CatalogService.Application.Features.V1.CoQuans.Queries.GetPagedCoQuan;
using CatalogService.Application.Parameters.CoQuans;
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
public class CoQuanController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CoQuanController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetPagedCoQuan = nameof(GetPagedCoQuan);
        public const string GetAllCoQuans = nameof(GetAllCoQuans);
        public const string GetCoQuanById = nameof(GetCoQuanById);
        public const string CreateCoQuan = nameof(CreateCoQuan);
        public const string UpdateCoQuan = nameof(UpdateCoQuan);
        public const string DeleteCoQuan = nameof(DeleteCoQuan);
    }

    [HttpPost("paging", Name = RouteNames.GetPagedCoQuan)]
    [ProducesResponseType(typeof(PagedResponse<IEnumerable<CoQuanDto>>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.CoQuans.View)]
    public async Task<ActionResult<PagedResponse<IEnumerable<CoQuanDto>>>> GetPagedLinhVucXuPhat([FromBody] CoQuanParameter request)
    {
        var query = new GetPagedCoQuanQuery(request);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetAllCoQuans)]
    [ProducesResponseType(typeof(IEnumerable<CoQuanDto>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.CoQuans.View)]
    public async Task<ActionResult<IEnumerable<CoQuanDto>>> GetAllCoQuans()
    {
        var query = new GetAllCoQuansQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetCoQuanById)]
    [ProducesResponseType(typeof(CoQuanDto), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.CoQuans.ViewById)]
    public async Task<ActionResult<CoQuanDto>> GetCoQuanById([FromQuery] int id)
    {
        var query = new GetCoQuanByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateCoQuan)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.CoQuans.Create)]
    public async Task<ActionResult<ApiResult<CoQuanDto>>> CreateCoQuan([FromBody] CreateCoQuanDto model)
    {
        var command = _mapper.Map<CreateCoQuanCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}", Name = RouteNames.UpdateCoQuan)]
    [ProducesResponseType(typeof(ApiResult<CoQuanDto>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.CoQuans.Edit)]
    public async Task<ActionResult<ApiResult<CoQuanDto>>> UpdateCoQuan([Required] int id, [FromBody] UpdateCoQuanCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}", Name = RouteNames.DeleteCoQuan)]
    //[Authorize(Permissions.CoQuans.Delete)]
    public async Task<ActionResult<bool>> DeleteCoQuan([Required] int id)
    {
        var command = new DeleteCoQuanCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}