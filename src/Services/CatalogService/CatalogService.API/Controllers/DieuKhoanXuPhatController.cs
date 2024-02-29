using System.ComponentModel.DataAnnotations;
using System.Net;
using AutoMapper;
using CatalogService.Application.Common.Models.DieuKhoanXuPhats;
using CatalogService.Application.Features.V1.DieuKhoanXuPhats.Commands.CreateDieuKhoanXuPhat;
using CatalogService.Application.Features.V1.DieuKhoanXuPhats.Commands.DeleteDieuKhoanXuPhat;
using CatalogService.Application.Features.V1.DieuKhoanXuPhats.Commands.UpdateDieuKhoanXuPhat;
using CatalogService.Application.Features.V1.DieuKhoanXuPhats.Queries.GetDieuKhoanXuPhatById;
using CatalogService.Application.Features.V1.DieuKhoanXuPhats.Queries.GetDieuKhoanXuPhats;
using CatalogService.Application.Parameters.DieuKhoanXuPhats;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.SeedWord;

namespace CatalogService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DieuKhoanXuPhatController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public DieuKhoanXuPhatController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetDieuKhoanXuPhats = nameof(GetDieuKhoanXuPhats);
        public const string CreateDieuKhoanXuPhat = nameof(CreateDieuKhoanXuPhat);
        public const string UpdateDieuKhoanXuPhat = nameof(UpdateDieuKhoanXuPhat);
        public const string DeleteDieuKhoanXuPhat = nameof(DeleteDieuKhoanXuPhat);
        public const string GetDieuKhoanXuPhatById = nameof(GetDieuKhoanXuPhatById);
    }

    [HttpPost("paging", Name = RouteNames.GetDieuKhoanXuPhats)]
    [ProducesResponseType(typeof(PagedResponse<IEnumerable<DieuKhoanXuPhatDto>>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<PagedResponse<IEnumerable<DieuKhoanXuPhatDto>>>> GetDieuKhoanXuPhats([FromBody] DieuKhoanXuPhatParameter request)
    {
        var query = new GetDieuKhoanXuPhatsQuery(request);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id:int}", Name = RouteNames.GetDieuKhoanXuPhatById)]
    [ProducesResponseType(typeof(DieuKhoanXuPhatDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<DieuKhoanXuPhatDto>> GetDieuKhoanXuPhatById([Required] int id)
    {
        var query = new GetDieuKhoanXuPhatByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateDieuKhoanXuPhat)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ApiResult<DieuKhoanXuPhatDto>>> CreateDieuKhoanXuPhat([FromBody] CreateDieuKhoanXuPhatDto model)
    {
        var command = _mapper.Map<CreateDieuKhoanXuPhatCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}", Name = RouteNames.UpdateDieuKhoanXuPhat)]
    [ProducesResponseType(typeof(ApiResult<DieuKhoanXuPhatDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ApiResult<DieuKhoanXuPhatDto>>> UpdateDieuKhoanXuPhat([Required] int id, [FromBody] UpdateDieuKhoanXuPhatCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}", Name = RouteNames.DeleteDieuKhoanXuPhat)]
    public async Task<ActionResult<bool>> DeleteDieuKhoanXuPhat([Required] int id)
    {
        var command = new DeleteDieuKhoanXuPhatCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}