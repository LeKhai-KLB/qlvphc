using AutoMapper;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Shared.SeedWord;
using CatalogService.Application.Common.Models.LinhVucXuPhats;
using CatalogService.Application.Features.V1.LinhVucXuPhats.Commands.DeleteLinhVucXuPhat;
using CatalogService.Application.Features.V1.LinhVucXuPhats.Commands.UpdateLinhVucXuPhat;
using CatalogService.Application.Features.V1.LinhVucXuPhats.Commands.CreateLinhVucXuPhat;
using CatalogService.Application.Features.V1.LinhVucXuPhats.Queries.GetLinhVucXuPhatById;
using Microsoft.AspNetCore.Authorization;
using Shared.Common.Constants;
using CatalogService.Application.Features.V1.LinhVucXuPhats.Queries.GetAllLinhVucXuPhat;

namespace CatalogService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class LinhVucXuPhatController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public LinhVucXuPhatController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetLinhVucXuPhatById = nameof(GetLinhVucXuPhatById);
        public const string CreateLinhVucXuPhat = nameof(CreateLinhVucXuPhat);
        public const string UpdateLinhVucXuPhat = nameof(UpdateLinhVucXuPhat);
        public const string DeleteLinhVucXuPhat = nameof(DeleteLinhVucXuPhat);
    }

    [HttpGet(Name = RouteNames.GetLinhVucXuPhatById)]
    [ProducesResponseType(typeof(IEnumerable<LinhVucXuPhatDto>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.LinhVucXuPhats.View)]
    public async Task<ActionResult<IEnumerable<LinhVucXuPhatDto>>> GetAllLinhVucXuPhat()
    {
        var query = new GetAllLinhVucXuPhatQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet(Name = RouteNames.GetLinhVucXuPhatById)]
    [ProducesResponseType(typeof(IEnumerable<LinhVucXuPhatDto>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.LinhVucXuPhats.ViewById)]
    public async Task<ActionResult<LinhVucXuPhatDto>> GetLinhVucXuPhatById([FromQuery] int id)
    {
        var query = new GetLinhVucXuPhatByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateLinhVucXuPhat)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.LinhVucXuPhats.Create)]
    public async Task<ActionResult<ApiResult<LinhVucXuPhatDto>>> CreateLinhVucXuPhat([FromBody] CreateLinhVucXuPhatDto model)
    {
        var command = _mapper.Map<CreateLinhVucXuPhatCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}", Name = RouteNames.UpdateLinhVucXuPhat)]
    [ProducesResponseType(typeof(ApiResult<LinhVucXuPhatDto>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.LinhVucXuPhats.Edit)]
    public async Task<ActionResult<ApiResult<LinhVucXuPhatDto>>> UpdateLinhVucXuPhat([Required] int id, [FromBody] UpdateLinhVucXuPhatCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}", Name = RouteNames.DeleteLinhVucXuPhat)]
    [Authorize(Permissions.LinhVucXuPhats.Delete)]
    public async Task<ActionResult<bool>> DeleteLinhVucXuPhat([Required] int id)
    {
        var command = new DeleteLinhVucXuPhatCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}