using AutoMapper;
using CatalogService.Application.Common.Models.VanBanLienQuans;
using CatalogService.Application.Features.V1.VanBanLienQuans.Commands.CreateVanBanLienQuan;
using CatalogService.Application.Features.V1.VanBanLienQuans.Commands.DeleteVanBanLienQuan;
using CatalogService.Application.Features.V1.VanBanLienQuans.Commands.UpdateVanBanLienQuan;
using CatalogService.Application.Features.V1.VanBanLienQuans.Queries.GetVanBanLienQuanById;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Common.Constants;
using Shared.SeedWord;
using CatalogService.Application.Features.V1.VanBanLienQuans.Queries.GetPagedByVanBanPhapLuatId;
using CatalogService.Application.Parameters.VanBanLienQuans;

namespace CatalogService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class VanBanLienQuanController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public VanBanLienQuanController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetPagedByVanBanPhapLuatId = nameof(GetPagedByVanBanPhapLuatId);
        public const string GetVanBanLienQuanById = nameof(GetVanBanLienQuanById);
        public const string CreateVanBanLienQuan = nameof(CreateVanBanLienQuan);
        public const string UpdateVanBanLienQuan = nameof(UpdateVanBanLienQuan);
        public const string DeleteVanBanLienQuan = nameof(DeleteVanBanLienQuan);
    }

    [HttpPost("paging", Name = RouteNames.GetPagedByVanBanPhapLuatId)]
    [ProducesResponseType(typeof(PagedResponse<IEnumerable<VanBanLienQuanDto>>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<PagedResponse<IEnumerable<VanBanLienQuanDto>>>> GetPagedByVanBanPhapLuatId([FromBody] VanBanLienQuanParameter request)
    {
        var query = new GetPagedByVanBanPhapLuatIdQuery(request);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetVanBanLienQuanById)]
    [ProducesResponseType(typeof(VanBanLienQuanDto), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.VanBanLienQuans.ViewById)]
    public async Task<ActionResult<VanBanLienQuanDto>> GetVanBanLienQuanById([FromQuery] int id)
    {
        var query = new GetVanBanLienQuanByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateVanBanLienQuan)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.VanBanLienQuans.Create)]
    public async Task<ActionResult<ApiResult<VanBanLienQuanDto>>> CreateVanBanLienQuan([FromBody] CreateVanBanLienQuanDto model)
    {
        var command = _mapper.Map<CreateVanBanLienQuanCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}", Name = RouteNames.UpdateVanBanLienQuan)]
    [ProducesResponseType(typeof(ApiResult<VanBanLienQuanDto>), (int)HttpStatusCode.OK)]
    [Authorize(Permissions.VanBanLienQuans.Edit)]
    public async Task<ActionResult<ApiResult<VanBanLienQuanDto>>> UpdateVanBanLienQuan([Required] int id, [FromBody] UpdateVanBanLienQuanCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}", Name = RouteNames.DeleteVanBanLienQuan)]
    [Authorize(Permissions.VanBanLienQuans.Delete)]
    public async Task<ActionResult<bool>> DeleteVanBanLienQuan([Required] int id)
    {
        var command = new DeleteVanBanLienQuanCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}