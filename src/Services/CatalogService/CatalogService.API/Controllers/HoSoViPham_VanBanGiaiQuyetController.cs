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
        public const string GetPagedHoSoXuLyViPham_VanBanGiaiQuyet = nameof(GetPagedHoSoXuLyViPham_VanBanGiaiQuyet);
        public const string CreateHoSoXuLyViPham_VanBanGiaiQuyet = nameof(CreateHoSoXuLyViPham_VanBanGiaiQuyet);
        public const string UpdateHoSoXuLyViPham_VanBanGiaiQuyet = nameof(UpdateHoSoXuLyViPham_VanBanGiaiQuyet);
        public const string DeleteHoSoXuLyViPham_VanBanGiaiQuyet = nameof(DeleteHoSoXuLyViPham_VanBanGiaiQuyet);
        public const string GetHoSoXuLyViPham_VanBanGiaiQuyetById = nameof(GetHoSoXuLyViPham_VanBanGiaiQuyetById);
    }

    [HttpPost("paging", Name = RouteNames.GetPagedHoSoXuLyViPham_VanBanGiaiQuyet)]
    [ProducesResponseType(typeof(PagedResponse<IEnumerable<HoSoXuLyViPham_VanBanGiaiQuyetDto>>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.HSVPVanBanGiaiQuyets.View)]
    public async Task<ActionResult<PagedResponse<IEnumerable<HoSoXuLyViPham_VanBanGiaiQuyetDto>>>> GetHSVPVanBanGiaiQuyets([FromBody] HSVPVanBanGiaiQuyetParameter request)
    {
        var query = new GetPagedVanBanByHSVPIdQuery(request);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet(Name = RouteNames.GetHoSoXuLyViPham_VanBanGiaiQuyetById)]
    [ProducesResponseType(typeof(HoSoXuLyViPham_VanBanGiaiQuyetDto), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.HSVPVanBanGiaiQuyets.ViewById)]
    public async Task<ActionResult<HoSoXuLyViPham_VanBanGiaiQuyetDto>> GetHSVPVanBanGiaiQuyetById([Required] int hosoxulyviphamId, [Required] int vanbangiaiquyetId)
    {
        var query = new GetHoSoXuLyViPham_VanBanGiaiQuyetByIdQuery(hosoxulyviphamId, vanbangiaiquyetId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateHoSoXuLyViPham_VanBanGiaiQuyet)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.HSVPVanBanGiaiQuyets.Create)]
    public async Task<ActionResult<ApiResult<HoSoXuLyViPham_VanBanGiaiQuyetDto>>> CreateHSVPVanBanGiaiQuyet([FromBody] CreateHoSoXuLyViPham_VanBanGiaiQuyetDto model)
    {
        var command = _mapper.Map<CreateHoSoXuLyViPham_VanBanGiaiQuyetCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut(Name = RouteNames.UpdateHoSoXuLyViPham_VanBanGiaiQuyet)]
    [ProducesResponseType(typeof(ApiResult<HoSoXuLyViPham_VanBanGiaiQuyetDto>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.HSVPVanBanGiaiQuyets.Edit)]
    public async Task<ActionResult<ApiResult<HoSoXuLyViPham_VanBanGiaiQuyetDto>>> UpdateHSVPVanBanGiaiQuyet([FromBody] UpdateHoSoXuLyViPham_VanBanGiaiQuyetCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete(Name = RouteNames.DeleteHoSoXuLyViPham_VanBanGiaiQuyet)]
    [Authorize(Permissions.HSVPVanBanGiaiQuyets.Delete)]
    public async Task<ActionResult<bool>> DeleteHSVPVanBanGiaiQuyet([Required] int hosoxulyviphamId, [Required] int vanbangiaiquyetId)
    {
        var command = new DeleteHoSoXuLyViPham_VanBanGiaiQuyetCommand(hosoxulyviphamId, vanbangiaiquyetId);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}