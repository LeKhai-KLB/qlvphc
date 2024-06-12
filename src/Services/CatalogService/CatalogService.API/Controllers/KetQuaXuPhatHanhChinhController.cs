using AutoMapper;
using CatalogService.Application.Common.Models.KetQuaXuPhatHanhChinhs;
using CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Commands.CreateKetQuaXuPhatHanhChinh;
using CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Commands.DeleteKetQuaXuPhatHanhChinh;
using CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Commands.UpdateKetQuaXuPhatHanhChinh;
using CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Queries.GetAllKetQuaXuPhatHanhChinhs;
using CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Queries.GetKetQuaXuPhatHanhChinhById;
using CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Queries.GetPagedKetQuaXuPhatHanhChinh;
using CatalogService.Application.Parameters.KetQuaXuPhatHanhChinhs;
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
[Authorize(AuthenticationSchemes = "Bearer")]
public class KetQuaXuPhatHanhChinhController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public KetQuaXuPhatHanhChinhController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetPagedKetQuaXuPhatHanhChinh = nameof(GetPagedKetQuaXuPhatHanhChinh);
        public const string GetAllKetQuaXuPhatHanhChinhs = nameof(GetAllKetQuaXuPhatHanhChinhs);
        public const string GetKetQuaXuPhatHanhChinhById = nameof(GetKetQuaXuPhatHanhChinhById);
        public const string CreateKetQuaXuPhatHanhChinh = nameof(CreateKetQuaXuPhatHanhChinh);
        public const string UpdateKetQuaXuPhatHanhChinh = nameof(UpdateKetQuaXuPhatHanhChinh);
        public const string DeleteKetQuaXuPhatHanhChinh = nameof(DeleteKetQuaXuPhatHanhChinh);
    }

    [HttpPost("paging", Name = RouteNames.GetPagedKetQuaXuPhatHanhChinh)]
    [ProducesResponseType(typeof(PagedResponse<IEnumerable<KetQuaXuPhatHanhChinhDto>>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.KetQuaXuPhatHanhChinhs.View)]
    public async Task<ActionResult<PagedResponse<IEnumerable<KetQuaXuPhatHanhChinhDto>>>> GetPagedLinhVucXuPhat([FromBody] KetQuaXuPhatHanhChinhParameter request)
    {
        var query = new GetPagedKetQuaXuPhatHanhChinhQuery(request);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetAllKetQuaXuPhatHanhChinhs)]
    [ProducesResponseType(typeof(IEnumerable<KetQuaXuPhatHanhChinhDto>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.KetQuaXuPhatHanhChinhs.View)]
    public async Task<ActionResult<IEnumerable<KetQuaXuPhatHanhChinhDto>>> GetAllKetQuaXuPhatHanhChinhs()
    {
        var query = new GetAllKetQuaXuPhatHanhChinhsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetKetQuaXuPhatHanhChinhById)]
    [ProducesResponseType(typeof(KetQuaXuPhatHanhChinhDto), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.KetQuaXuPhatHanhChinhs.ViewById)]
    public async Task<ActionResult<KetQuaXuPhatHanhChinhDto>> GetKetQuaXuPhatHanhChinhById([FromQuery] int id)
    {
        var query = new GetKetQuaXuPhatHanhChinhByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateKetQuaXuPhatHanhChinh)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.KetQuaXuPhatHanhChinhs.Create)]
    public async Task<ActionResult<ApiResult<KetQuaXuPhatHanhChinhDto>>> CreateKetQuaXuPhatHanhChinh([FromBody] CreateKetQuaXuPhatHanhChinhDto model)
    {
        var command = _mapper.Map<CreateKetQuaXuPhatHanhChinhCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}", Name = RouteNames.UpdateKetQuaXuPhatHanhChinh)]
    [ProducesResponseType(typeof(ApiResult<KetQuaXuPhatHanhChinhDto>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.KetQuaXuPhatHanhChinhs.Edit)]
    public async Task<ActionResult<ApiResult<KetQuaXuPhatHanhChinhDto>>> UpdateKetQuaXuPhatHanhChinh([Required] int id, [FromBody] UpdateKetQuaXuPhatHanhChinhCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}", Name = RouteNames.DeleteKetQuaXuPhatHanhChinh)]
    [Authorize(Permissions.KetQuaXuPhatHanhChinhs.Delete)]
    public async Task<ActionResult<bool>> DeleteKetQuaXuPhatHanhChinh([Required] int id)
    {
        var command = new DeleteKetQuaXuPhatHanhChinhCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}