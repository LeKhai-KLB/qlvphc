using System.ComponentModel.DataAnnotations;
using System.Net;
using AutoMapper;
using CatalogService.Application.Common.Models.DieuKhoanBoSungKhacPhucs;
using CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Commands.CreateDieuKhoanBoSungKhacPhuc;
using CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Commands.DeleteDieuKhoanBoSungKhacPhuc;
using CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Commands.UpdateDieuKhoanBoSungKhacPhuc;
using CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Queries.GetDieuKhoanBoSungKhacPhucById;
using CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Queries.GetAllDieuKhoanBoSungKhacPhucs;
using CatalogService.Application.Parameters.DieuKhoanBoSungKhacPhucs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.SeedWord;
using CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Queries.GetPagedDieuKhoanBoSungKhacPhuc;
using Microsoft.AspNetCore.Authorization;
using Shared.Common.Constants;

namespace CatalogService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DieuKhoanBoSungKhacPhucController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public DieuKhoanBoSungKhacPhucController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetAllDieuKhoanBoSungKhacPhucs = nameof(GetAllDieuKhoanBoSungKhacPhucs);
        public const string GetPagedDieuKhoanBoSungKhacPhuc = nameof(GetPagedDieuKhoanBoSungKhacPhuc);
        public const string CreateDieuKhoanBoSungKhacPhuc = nameof(CreateDieuKhoanBoSungKhacPhuc);
        public const string UpdateDieuKhoanBoSungKhacPhuc = nameof(UpdateDieuKhoanBoSungKhacPhuc);
        public const string DeleteDieuKhoanBoSungKhacPhuc = nameof(DeleteDieuKhoanBoSungKhacPhuc);
        public const string GetDieuKhoanBoSungKhacPhucById = nameof(GetDieuKhoanBoSungKhacPhucById);
    }

    [HttpGet]
    [Route(RouteNames.GetAllDieuKhoanBoSungKhacPhucs)]
    [ProducesResponseType(typeof(IEnumerable<DieuKhoanBoSungKhacPhucDto>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.DieuKhoanBoSungKhacPhucs.View)]
    public async Task<ActionResult<IEnumerable<DieuKhoanBoSungKhacPhucDto>>> GetAllDieuKhoanBoSungKhacPhucs([FromBody] DieuKhoanBoSungKhacPhucDropDownParameter request)
    {
        var query = new GetAllDieuKhoanBoSungKhacPhucsQuery(request);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("paging", Name = RouteNames.GetPagedDieuKhoanBoSungKhacPhuc)]
    [ProducesResponseType(typeof(PagedResponse<IEnumerable<DieuKhoanBoSungKhacPhucDto>>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<PagedResponse<IEnumerable<DieuKhoanBoSungKhacPhucDto>>>> GetDieuKhoanBoSungKhacPhucs([FromBody] DieuKhoanBoSungKhacPhucParameter request)
    {
        var query = new GetPagedDieuKhoanBoSungKhacPhucQuery(request);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id:int}", Name = RouteNames.GetDieuKhoanBoSungKhacPhucById)]
    [ProducesResponseType(typeof(DieuKhoanBoSungKhacPhucDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<DieuKhoanBoSungKhacPhucDto>> GetDieuKhoanBoSungKhacPhucById([Required] int id)
    {
        var query = new GetDieuKhoanBoSungKhacPhucByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateDieuKhoanBoSungKhacPhuc)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ApiResult<DieuKhoanBoSungKhacPhucDto>>> CreateDieuKhoanBoSungKhacPhuc([FromBody] CreateDieuKhoanBoSungKhacPhucDto model)
    {
        var command = _mapper.Map<CreateDieuKhoanBoSungKhacPhucCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}", Name = RouteNames.UpdateDieuKhoanBoSungKhacPhuc)]
    [ProducesResponseType(typeof(ApiResult<DieuKhoanBoSungKhacPhucDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ApiResult<DieuKhoanBoSungKhacPhucDto>>> UpdateDieuKhoanBoSungKhacPhuc([Required] int id, [FromBody] UpdateDieuKhoanBoSungKhacPhucCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}", Name = RouteNames.DeleteDieuKhoanBoSungKhacPhuc)]
    public async Task<ActionResult<bool>> DeleteDieuKhoanBoSungKhacPhuc([Required] int id)
    {
        var command = new DeleteDieuKhoanBoSungKhacPhucCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}