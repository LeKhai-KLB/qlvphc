using System.ComponentModel.DataAnnotations;
using System.Net;
using AutoMapper;
using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Commands.CreateHSVPVanBanGiaiQuyet;
using CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Commands.DeleteHSVPVanBanGiaiQuyet;
using CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Commands.UpdateHSVPVanBanGiaiQuyet;
using CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Queries.GetHSVPVanBanById;
using CatalogService.Application.Parameters.HoSoXuLyViPhams;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.SeedWord;
using CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Queries.GetPagedVanBanByHSVPId;
using Microsoft.AspNetCore.Authorization;
using Shared.Common.Constants;

namespace CatalogService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HoSoViPham_VanBanGiaiQuyetController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public HoSoViPham_VanBanGiaiQuyetController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetPagedHSVPVanBanGiaiQuyet = nameof(GetPagedHSVPVanBanGiaiQuyet);
        public const string CreateHSVPVanBanGiaiQuyet = nameof(CreateHSVPVanBanGiaiQuyet);
        public const string UpdateHSVPVanBanGiaiQuyet = nameof(UpdateHSVPVanBanGiaiQuyet);
        public const string DeleteHSVPVanBanGiaiQuyet = nameof(DeleteHSVPVanBanGiaiQuyet);
        public const string GetHSVPVanBanGiaiQuyetById = nameof(GetHSVPVanBanGiaiQuyetById);
    }

    [HttpPost("paging", Name = RouteNames.GetPagedHSVPVanBanGiaiQuyet)]
    [ProducesResponseType(typeof(PagedResponse<IEnumerable<HoSoViPham_VanBanGiaiQuyetDto>>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.HSVPVanBanGiaiQuyets.View)]
    public async Task<ActionResult<PagedResponse<IEnumerable<HoSoViPham_VanBanGiaiQuyetDto>>>> GetHSVPVanBanGiaiQuyets([FromBody] HSVPVanBanGiaiQuyetParameter request)
    {
        var query = new GetPagedVanBanByHSVPIdQuery(request);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id:int}", Name = RouteNames.GetHSVPVanBanGiaiQuyetById)]
    [ProducesResponseType(typeof(HoSoViPham_VanBanGiaiQuyetDto), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.HSVPVanBanGiaiQuyets.ViewById)]
    public async Task<ActionResult<HoSoViPham_VanBanGiaiQuyetDto>> GetHSVPVanBanGiaiQuyetById([Required] int hsId, [Required] int vbId)
    {
        var query = new GetHSVPVanBanByIdQuery(hsId, vbId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateHSVPVanBanGiaiQuyet)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.HSVPVanBanGiaiQuyets.Create)]
    public async Task<ActionResult<ApiResult<HoSoViPham_VanBanGiaiQuyetDto>>> CreateHSVPVanBanGiaiQuyet([FromBody] CreateHoSoViPham_VanBanGiaiQuyetDto model)
    {
        var command = _mapper.Map<CreateHSVPVanBanGiaiQuyetCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut(Name = RouteNames.UpdateHSVPVanBanGiaiQuyet)]
    [ProducesResponseType(typeof(ApiResult<HoSoViPham_VanBanGiaiQuyetDto>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.HSVPVanBanGiaiQuyets.Edit)]
    public async Task<ActionResult<ApiResult<HoSoViPham_VanBanGiaiQuyetDto>>> UpdateHSVPVanBanGiaiQuyet([Required] int hosoxulyviphamId, [Required] int vanbangiaiquyetId, [FromBody] UpdateHSVPVanBanGiaiQuyetCommand command)
    {
        command.SetId(hosoxulyviphamId, vanbangiaiquyetId);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}", Name = RouteNames.DeleteHSVPVanBanGiaiQuyet)]
    [Authorize(Permissions.HSVPVanBanGiaiQuyets.Delete)]
    public async Task<ActionResult<bool>> DeleteHSVPVanBanGiaiQuyet([Required] int hsId, [Required] int vbId)
    {
        var command = new DeleteHSVPVanBanGiaiQuyetCommand(hsId, vbId);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}