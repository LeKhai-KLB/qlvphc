using AutoMapper;
using CatalogService.Application.Common.Models.ThamQuyenXuPhats;
using CatalogService.Application.Features.V1.ThamQuyenXuPhats.Commands.CreateThamQuyenXuPhat;
using CatalogService.Application.Features.V1.ThamQuyenXuPhats.Commands.DeleteThamQuyenXuPhat;
using CatalogService.Application.Features.V1.ThamQuyenXuPhats.Commands.UpdateThamQuyenXuPhat;
using CatalogService.Application.Features.V1.ThamQuyenXuPhats.Queries.GetThamQuyenXuPhatById;
using CatalogService.Application.Features.V1.ThamQuyenXuPhats.Queries.GetPageThamQuyenXuPhat;
using CatalogService.Application.Parameters.ThamQuyenXuPhats;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Common.Constants;
using Shared.SeedWord;
using System.ComponentModel.DataAnnotations;
using System.Net;
using CatalogService.Application.Features.V1.ThamQuyenXuPhats.Queries.GetAllThamQuyenXuPhats;

namespace CatalogService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize(AuthenticationSchemes = "Bearer")]
public class ThamQuyenXuPhatController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ThamQuyenXuPhatController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetAllThamQuyenXuPhats = nameof(GetAllThamQuyenXuPhats);
        public const string GetPageThamQuyenXuPhat = nameof(GetPageThamQuyenXuPhat);
        public const string CreateThamQuyenXuPhat = nameof(CreateThamQuyenXuPhat);
        public const string UpdateThamQuyenXuPhat = nameof(UpdateThamQuyenXuPhat);
        public const string DeleteThamQuyenXuPhat = nameof(DeleteThamQuyenXuPhat);
        public const string GetThamQuyenXuPhatById = nameof(GetThamQuyenXuPhatById);
    }

    [HttpGet]
    [Route(RouteNames.GetAllThamQuyenXuPhats)]
    [ProducesResponseType(typeof(IEnumerable<ThamQuyenXuPhatDto>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.ThamQuyenXuPhats.View)]
    public async Task<ActionResult<IEnumerable<ThamQuyenXuPhatDto>>> GetAllThamQuyenXuPhats()
    {
        var query = new GetAllThamQuyenXuPhatsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("paging", Name = RouteNames.GetPageThamQuyenXuPhat)]
    [ProducesResponseType(typeof(PagedResponse<IEnumerable<ThamQuyenXuPhatDto>>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.ThamQuyenXuPhats.View)]
    public async Task<ActionResult<PagedResponse<IEnumerable<ThamQuyenXuPhatDto>>>> GetPageThamQuyenXuPhat([FromBody] ThamQuyenXuPhatParameter request)
    {
        var query = new GetPageThamQuyenXuPhatQuery(request);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id:int}", Name = RouteNames.GetThamQuyenXuPhatById)]
    [ProducesResponseType(typeof(ThamQuyenXuPhatDto), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.ThamQuyenXuPhats.ViewById)]
    public async Task<ActionResult<ThamQuyenXuPhatDto>> GetThamQuyenXuPhatById([Required] int id)
    {
        var query = new GetThamQuyenXuPhatByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateThamQuyenXuPhat)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.ThamQuyenXuPhats.Create)]
    public async Task<ActionResult<ApiResult<ThamQuyenXuPhatDto>>> CreateThamQuyenXuPhat([FromBody] CreateThamQuyenXuPhatDto model)
    {
        var command = _mapper.Map<CreateThamQuyenXuPhatCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}", Name = RouteNames.UpdateThamQuyenXuPhat)]
    [ProducesResponseType(typeof(ApiResult<ThamQuyenXuPhatDto>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.ThamQuyenXuPhats.Edit)]
    public async Task<ActionResult<ApiResult<ThamQuyenXuPhatDto>>> UpdateThamQuyenXuPhat([Required] int id, [FromBody] UpdateThamQuyenXuPhatCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}", Name = RouteNames.DeleteThamQuyenXuPhat)]
    //[Authorize(Permissions.ThamQuyenXuPhats.Delete)]
    public async Task<ActionResult<bool>> DeleteThamQuyenXuPhat([Required] int id)
    {
        var command = new DeleteThamQuyenXuPhatCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}