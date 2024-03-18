using AutoMapper;
using CatalogService.Application.Common.Models.LoaiVanBans;
using CatalogService.Application.Features.V1.LoaiVanBans.Commands.CreateLoaiVanBan;
using CatalogService.Application.Features.V1.LoaiVanBans.Commands.DeleteLoaiVanBan;
using CatalogService.Application.Features.V1.LoaiVanBans.Commands.UpdateLoaiVanBan;
using CatalogService.Application.Features.V1.LoaiVanBans.Queries.GetLoaiVanBanById;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Common.Constants;
using Shared.SeedWord;
using CatalogService.Application.Parameters.LoaiVanBans;
using CatalogService.Application.Features.V1.LoaiVanBans.Queries.GetPagedLoaiVanBanAsync;
using CatalogService.Application.Features.V1.LoaiVanBans.Queries.GetAllLoaiVanBans;

namespace CatalogService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize(AuthenticationSchemes = "Bearer")]
public class LoaiVanBanController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public LoaiVanBanController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetPagedLoaiVanBan = nameof(GetPagedLoaiVanBan);
        public const string GetAllLoaiVanBans = nameof(GetAllLoaiVanBans);
        public const string GetLoaiVanBanById = nameof(GetLoaiVanBanById);
        public const string CreateLoaiVanBan = nameof(CreateLoaiVanBan);
        public const string UpdateLoaiVanBan = nameof(UpdateLoaiVanBan);
        public const string DeleteLoaiVanBan = nameof(DeleteLoaiVanBan);
    }

    [HttpPost("paging", Name = RouteNames.GetPagedLoaiVanBan)]
    [ProducesResponseType(typeof(PagedResponse<IEnumerable<LoaiVanBanDto>>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.LoaiVanBans.View)]
    public async Task<ActionResult<PagedResponse<IEnumerable<LoaiVanBanDto>>>> GetPagedLoaiVanBan([FromBody] LoaiVanBanParameter request)
    {
        var query = new GetPagedLoaiVanBanQuery(request);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetAllLoaiVanBans)]
    [ProducesResponseType(typeof(IEnumerable<LoaiVanBanDto>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.LoaiVanBans.View)]
    public async Task<ActionResult<IEnumerable<LoaiVanBanDto>>> GetAllLoaiVanBans()
    {
        var query = new GetAllLoaiVanBansQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetLoaiVanBanById)]
    [ProducesResponseType(typeof(LoaiVanBanDto), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.LoaiVanBans.ViewById)]
    public async Task<ActionResult<LoaiVanBanDto>> GetLoaiVanBanById([FromQuery] int id)
    {
        var query = new GetLoaiVanBanByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateLoaiVanBan)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.LoaiVanBans.Create)]
    public async Task<ActionResult<ApiResult<LoaiVanBanDto>>> CreateLoaiVanBan([FromBody] CreateLoaiVanBanDto model)
    {
        var command = _mapper.Map<CreateLoaiVanBanCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}", Name = RouteNames.UpdateLoaiVanBan)]
    [ProducesResponseType(typeof(ApiResult<LoaiVanBanDto>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.LoaiVanBans.Edit)]
    public async Task<ActionResult<ApiResult<LoaiVanBanDto>>> UpdateLoaiVanBan([Required] int id, [FromBody] UpdateLoaiVanBanCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}", Name = RouteNames.DeleteLoaiVanBan)]
    //[Authorize(Permissions.LoaiVanBans.Delete)]
    public async Task<ActionResult<bool>> DeleteLoaiVanBan([Required] int id)
    {
        var command = new DeleteLoaiVanBanCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}