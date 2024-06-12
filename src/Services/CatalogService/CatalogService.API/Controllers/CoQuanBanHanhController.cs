using AutoMapper;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Common.Constants;
using Shared.SeedWord;
using CatalogService.Application.Common.Models.CoQuanBanHanhs;
using CatalogService.Application.Features.V1.CoQuanBanHanhs.Queries.GetCoQuanBanHanhById;
using CatalogService.Application.Features.V1.CoQuanBanHanhs.Commands.CreateCoQuanBanHanh;
using CatalogService.Application.Features.V1.CoQuanBanHanhs.Commands.UpdateCoQuanBanHanh;
using CatalogService.Application.Features.V1.CoQuanBanHanhs.Commands.DeleteCoQuanBanHanh;
using CatalogService.Application.Features.V1.CoQuanBanHanhs.Queries.GetPagedCoQuanBanHanhAsync;
using CatalogService.Application.Parameters.CoQuanBanHanhs;
using CatalogService.Application.Features.V1.CoQuanBanHanhs.Queries.GetAllCoQuanBanHanhs;
namespace CatalogService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class CoQuanBanHanhController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CoQuanBanHanhController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetPagedCoQuanBanHanh = nameof(GetPagedCoQuanBanHanh);
        public const string GetAllCoQuanBanHanhs = nameof(GetAllCoQuanBanHanhs);
        public const string GetCoQuanBanHanhById = nameof(GetCoQuanBanHanhById);
        public const string CreateCoQuanBanHanh = nameof(CreateCoQuanBanHanh);
        public const string UpdateCoQuanBanHanh = nameof(UpdateCoQuanBanHanh);
        public const string DeleteCoQuanBanHanh = nameof(DeleteCoQuanBanHanh);
    }

    [HttpPost("paging", Name = RouteNames.GetPagedCoQuanBanHanh)]
    [ProducesResponseType(typeof(PagedResponse<IEnumerable<CoQuanBanHanhDto>>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.CoQuanBanHanhs.View)]
    public async Task<ActionResult<PagedResponse<IEnumerable<CoQuanBanHanhDto>>>> GetPagedLinhVucXuPhat([FromBody] CoQuanBanHanhParameter request)
    {
        var query = new GetPagedCoQuanBanHanhQuery(request);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetAllCoQuanBanHanhs)]
    [ProducesResponseType(typeof(IEnumerable<CoQuanBanHanhDto>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.CoQuanBanHanhs.View)]
    public async Task<ActionResult<IEnumerable<CoQuanBanHanhDto>>> GetAllCoQuanBanHanhs()
    {
        var query = new GetAllCoQuanBanHanhsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetCoQuanBanHanhById)]
    [ProducesResponseType(typeof(CoQuanBanHanhDto), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.CoQuanBanHanhs.ViewById)]
    public async Task<ActionResult<CoQuanBanHanhDto>> GetCoQuanBanHanhById([FromQuery] int id)
    {
        var query = new GetCoQuanBanHanhByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateCoQuanBanHanh)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.CoQuanBanHanhs.Create)]
    public async Task<ActionResult<ApiResult<CoQuanBanHanhDto>>> CreateCoQuanBanHanh([FromBody] CreateCoQuanBanHanhDto model)
    {
        var command = _mapper.Map<CreateCoQuanBanHanhCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}", Name = RouteNames.UpdateCoQuanBanHanh)]
    [ProducesResponseType(typeof(ApiResult<CoQuanBanHanhDto>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.CoQuanBanHanhs.Edit)]
    public async Task<ActionResult<ApiResult<CoQuanBanHanhDto>>> UpdateCoQuanBanHanh([Required] int id, [FromBody] UpdateCoQuanBanHanhCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}", Name = RouteNames.DeleteCoQuanBanHanh)]
    [Authorize(Permissions.CoQuanBanHanhs.Delete)]
    public async Task<ActionResult<bool>> DeleteCoQuanBanHanh([Required] int id)
    {
        var command = new DeleteCoQuanBanHanhCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}