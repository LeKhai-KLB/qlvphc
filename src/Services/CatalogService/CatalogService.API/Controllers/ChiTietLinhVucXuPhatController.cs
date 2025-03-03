using AutoMapper;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Shared.SeedWord;
using CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Commands.DeleteChiTietLinhVucXuPhat;
using CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Commands.UpdateChiTietLinhVucXuPhat;
using CatalogService.Application.Common.Models.ChiTietLinhVucXuPhats;
using CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Commands.CreateChiTietLinhVucXuPhat;
using CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Queries.GetChiTietLinhVucXuPhatById;
using Microsoft.AspNetCore.Authorization;
using Shared.Common.Constants;
using CatalogService.Application.Parameters.ChiTietLinhVucXuPhats;
using CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Queries.GetPagedByLinhVucXuPhatId;
namespace CatalogService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class ChiTietLinhVucXuPhatController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ChiTietLinhVucXuPhatController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetPagedByLinhVucXuPhatId = nameof(GetPagedByLinhVucXuPhatId);
        public const string GetChiTietLinhVucXuPhatById = nameof(GetChiTietLinhVucXuPhatById);
        public const string CreateChiTietLinhVucXuPhat = nameof(CreateChiTietLinhVucXuPhat);
        public const string UpdateChiTietLinhVucXuPhat = nameof(UpdateChiTietLinhVucXuPhat);
        public const string DeleteChiTietLinhVucXuPhat = nameof(DeleteChiTietLinhVucXuPhat);
    }

    [HttpPost("paging", Name = RouteNames.GetPagedByLinhVucXuPhatId)]
    [ProducesResponseType(typeof(PagedResponse<IEnumerable<ChiTietLinhVucXuPhatDto>>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.ChiTietLinhVucXuPhats.View)]
    public async Task<ActionResult<PagedResponse<IEnumerable<ChiTietLinhVucXuPhatDto>>>> GetPagedByLinhVucXuPhatId([FromBody] ChiTietLinhVucXuPhatParameter request)
    {
        var query = new GetPagedByLinhVucXuPhatIdQuery(request);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetChiTietLinhVucXuPhatById)]
    [ProducesResponseType(typeof(ChiTietLinhVucXuPhatDto), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.ChiTietLinhVucXuPhats.ViewById)]
    public async Task<ActionResult<ChiTietLinhVucXuPhatDto>> GetChiTietLinhVucXuPhatById([FromQuery] int id)
    {
        var query = new GetChiTietLinhVucXuPhatByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateChiTietLinhVucXuPhat)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.ChiTietLinhVucXuPhats.Create)]
    public async Task<ActionResult<ApiResult<ChiTietLinhVucXuPhatDto>>> CreateChiTietLinhVucXuPhat([FromBody] CreateChiTietLinhVucXuPhatDto model)
    {
        var command = _mapper.Map<CreateChiTietLinhVucXuPhatCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}", Name = RouteNames.UpdateChiTietLinhVucXuPhat)]
    [ProducesResponseType(typeof(ApiResult<ChiTietLinhVucXuPhatDto>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.ChiTietLinhVucXuPhats.Edit)]
    public async Task<ActionResult<ApiResult<ChiTietLinhVucXuPhatDto>>> UpdateChiTietLinhVucXuPhat([Required] int id, [FromBody] UpdateChiTietLinhVucXuPhatCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}", Name = RouteNames.DeleteChiTietLinhVucXuPhat)]
    [Authorize(Permissions.ChiTietLinhVucXuPhats.Delete)]
    public async Task<ActionResult<bool>> DeleteChiTietLinhVucXuPhat([Required] int id)
    {
        var command = new DeleteChiTietLinhVucXuPhatCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}