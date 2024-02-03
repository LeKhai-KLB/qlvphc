using AutoMapper;
using CatalogService.Application.Common.Models.VanBanPhapLuats;
using CatalogService.Application.Features.V1.VanBanPhapLuats.Commands.CreateVanBanPhapLuat;
using CatalogService.Application.Features.V1.VanBanPhapLuats.Commands.DeleteVanBanPhapLuat;
using CatalogService.Application.Features.V1.VanBanPhapLuats.Commands.UpdateVanBanPhapLuat;
using CatalogService.Application.Features.V1.VanBanPhapLuats.Queries.GetAllVanBanPhapLuat;
using CatalogService.Application.Features.V1.VanBanPhapLuats.Queries.GetVanBanPhapLuatById;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Common.Constants;
using Shared.SeedWord;
using CatalogService.Application.Parameters.VanBanPhapLuats;
using CatalogService.Application.Features.V1.VanBanPhapLuats.Queries.GetPagedVanBanPhapLuatAsync;

namespace CatalogService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class VanBanPhapLuatController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public VanBanPhapLuatController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetPagedVanBanPhapLuat = nameof(GetPagedVanBanPhapLuat);
        public const string GetAllVanBanPhapLuat = nameof(GetAllVanBanPhapLuat);
        public const string GetVanBanPhapLuatById = nameof(GetVanBanPhapLuatById);
        public const string CreateVanBanPhapLuat = nameof(CreateVanBanPhapLuat);
        public const string UpdateVanBanPhapLuat = nameof(UpdateVanBanPhapLuat);
        public const string DeleteVanBanPhapLuat = nameof(DeleteVanBanPhapLuat);
    }

    [HttpPost("paging", Name = RouteNames.GetPagedVanBanPhapLuat)]
    [ProducesResponseType(typeof(PagedResponse<IEnumerable<VanBanPhapLuatDto>>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.VanBanPhapLuats.View)]
    public async Task<ActionResult<PagedResponse<IEnumerable<VanBanPhapLuatDto>>>> GetPagedVanBanPhapLuat([FromBody] VanBanPhapLuatParameter request)
    {
        var query = new GetPagedVanBanPhapLuatQuery(request);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetAllVanBanPhapLuat)]
    [ProducesResponseType(typeof(IEnumerable<VanBanPhapLuatDto>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.VanBanPhapLuats.View)]
    public async Task<ActionResult<IEnumerable<VanBanPhapLuatDto>>> GetAllVanBanPhapLuat()
    {
        var query = new GetAllVanBanPhapLuatQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetVanBanPhapLuatById)]
    [ProducesResponseType(typeof(VanBanPhapLuatDto), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.VanBanPhapLuats.ViewById)]
    public async Task<ActionResult<VanBanPhapLuatDto>> GetVanBanPhapLuatById([FromQuery] int id)
    {
        var query = new GetVanBanPhapLuatByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateVanBanPhapLuat)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.VanBanPhapLuats.Create)]
    public async Task<ActionResult<ApiResult<VanBanPhapLuatDto>>> CreateVanBanPhapLuat([FromBody] CreateVanBanPhapLuatDto model)
    {
        var command = _mapper.Map<CreateVanBanPhapLuatCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}", Name = RouteNames.UpdateVanBanPhapLuat)]
    [ProducesResponseType(typeof(ApiResult<VanBanPhapLuatDto>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.VanBanPhapLuats.Edit)]
    public async Task<ActionResult<ApiResult<VanBanPhapLuatDto>>> UpdateVanBanPhapLuat([Required] int id, [FromBody] UpdateVanBanPhapLuatCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}", Name = RouteNames.DeleteVanBanPhapLuat)]
    [Authorize(Permissions.VanBanPhapLuats.Delete)]
    public async Task<ActionResult<bool>> DeleteVanBanPhapLuat([Required] int id)
    {
        var command = new DeleteVanBanPhapLuatCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}