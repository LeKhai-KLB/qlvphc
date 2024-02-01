using AutoMapper;
using CatalogService.Application.Common.Models.VanBanGiaiQuyets;
using CatalogService.Application.Features.V1.VanBanGiaiQuyets.Commands.CreateVanBanGiaiQuyet;
using CatalogService.Application.Features.V1.VanBanGiaiQuyets.Commands.DeleteVanBanGiaiQuyet;
using CatalogService.Application.Features.V1.VanBanGiaiQuyets.Commands.UpdateVanBanGiaiQuyet;
using CatalogService.Application.Features.V1.VanBanGiaiQuyets.Queries.GetAllVanBanGiaiQuyet;
using CatalogService.Application.Features.V1.VanBanGiaiQuyets.Queries.GetPagedVanBanGiaiQuyetAsync;
using CatalogService.Application.Features.V1.VanBanGiaiQuyets.Queries.GetVanBanGiaiQuyetById;
using CatalogService.Application.Parameters.VanBanGiaiQuyets;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.SeedWord;

namespace CatalogService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class VanBanGiaiQuyetController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public VanBanGiaiQuyetController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetPagedVanBanGiaiQuyet = nameof(GetPagedVanBanGiaiQuyet);
        public const string GetAllVanBanGiaiQuyet = nameof(GetAllVanBanGiaiQuyet);
        public const string GetVanBanGiaiQuyetById = nameof(GetVanBanGiaiQuyetById);
        public const string CreateVanBanGiaiQuyet = nameof(CreateVanBanGiaiQuyet);
        public const string UpdateVanBanGiaiQuyet = nameof(UpdateVanBanGiaiQuyet);
        public const string DeleteVanBanGiaiQuyet = nameof(DeleteVanBanGiaiQuyet);
    }

    [HttpPost("paging", Name = RouteNames.GetPagedVanBanGiaiQuyet)]
    [ProducesResponseType(typeof(PagedResponse<IEnumerable<VanBanGiaiQuyetDto>>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<PagedResponse<IEnumerable<VanBanGiaiQuyetDto>>>> GetPagedVanBanGiaiQuyet([FromBody] VanBanGiaiQuyetParameter request)
    {
        var query = new GetPagedVanBanGiaiQuyetQuery(request);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetAllVanBanGiaiQuyet)]
    [ProducesResponseType(typeof(IEnumerable<VanBanGiaiQuyetDto>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.VanBanGiaiQuyets.View)]
    public async Task<ActionResult<IEnumerable<VanBanGiaiQuyetDto>>> GetAllVanBanGiaiQuyet()
    {
        var query = new GetAllVanBanGiaiQuyetQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetVanBanGiaiQuyetById)]
    [ProducesResponseType(typeof(VanBanGiaiQuyetDto), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.VanBanGiaiQuyets.ViewById)]
    public async Task<ActionResult<VanBanGiaiQuyetDto>> GetVanBanGiaiQuyetById([FromQuery] int id)
    {
        var query = new GetVanBanGiaiQuyetByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateVanBanGiaiQuyet)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.VanBanGiaiQuyets.Create)]
    public async Task<ActionResult<ApiResult<VanBanGiaiQuyetDto>>> CreateVanBanGiaiQuyet([FromBody] CreateVanBanGiaiQuyetDto model)
    {
        var command = _mapper.Map<CreateVanBanGiaiQuyetCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}", Name = RouteNames.UpdateVanBanGiaiQuyet)]
    [ProducesResponseType(typeof(ApiResult<VanBanGiaiQuyetDto>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.VanBanGiaiQuyets.Edit)]
    public async Task<ActionResult<ApiResult<VanBanGiaiQuyetDto>>> UpdateVanBanGiaiQuyet([Required] int id, [FromBody] UpdateVanBanGiaiQuyetCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}", Name = RouteNames.DeleteVanBanGiaiQuyet)]
    //[Authorize(Permissions.VanBanGiaiQuyets.Delete)]
    public async Task<ActionResult<bool>> DeleteVanBanGiaiQuyet([Required] int id)
    {
        var command = new DeleteVanBanGiaiQuyetCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}