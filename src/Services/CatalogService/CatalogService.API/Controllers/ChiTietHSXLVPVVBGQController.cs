using AutoMapper;
using CatalogService.Application.Common.Models.ChiTietHSXLVPVVBGQs;
using CatalogService.Application.Features.V1.ChiTietHSXLVPVVBGQs.Commands.CreateChiTietHSXLVPVVBGQ;
using CatalogService.Application.Features.V1.ChiTietHSXLVPVVBGQs.Commands.DeleteChiTietHSXLVPVVBGQ;
using CatalogService.Application.Features.V1.ChiTietHSXLVPVVBGQs.Commands.UpdateChiTietHSXLVPVVBGQ;
using CatalogService.Application.Features.V1.ChiTietHSXLVPVVBGQs.Queries.GetChiTietHSXLVPVVBGQById;
using CatalogService.Application.Features.V1.ChiTietHSXLVPVVBGQs.Queries.GetPagedChiTietHSXLVPVVBGQ;
using CatalogService.Application.Parameters.ChiTietHSXLVPVVBGQs;
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
//[Authorize(AuthenticationSchemes = "Bearer")]
public class ChiTietHSXLVPVVBGQController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ChiTietHSXLVPVVBGQController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetPagedChiTietHSXLVPVVBGQ = nameof(GetPagedChiTietHSXLVPVVBGQ);
        public const string GetChiTietHSXLVPVVBGQById = nameof(GetChiTietHSXLVPVVBGQById);
        public const string CreateChiTietHSXLVPVVBGQ = nameof(CreateChiTietHSXLVPVVBGQ);
        public const string UpdateChiTietHSXLVPVVBGQ = nameof(UpdateChiTietHSXLVPVVBGQ);
        public const string DeleteChiTietHSXLVPVVBGQ = nameof(DeleteChiTietHSXLVPVVBGQ);
    }

    [HttpPost("paging", Name = RouteNames.GetPagedChiTietHSXLVPVVBGQ)]
    [ProducesResponseType(typeof(PagedResponse<IEnumerable<ChiTietHSXLVPVVBGQDto>>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.ChiTietHSXLVPVVBGQs.View)]
    public async Task<ActionResult<PagedResponse<IEnumerable<ChiTietHSXLVPVVBGQDto>>>> GetPagedLinhVucXuPhat([FromBody] ChiTietHSXLVPVVBGQParameter request)
    {
        var query = new GetPagedChiTietHSXLVPVVBGQQuery(request);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetChiTietHSXLVPVVBGQById)]
    [ProducesResponseType(typeof(ChiTietHSXLVPVVBGQDto), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.ChiTietHSXLVPVVBGQs.ViewById)]
    public async Task<ActionResult<ChiTietHSXLVPVVBGQDto>> GetChiTietHSXLVPVVBGQById([FromQuery] int id)
    {
        var query = new GetChiTietHSXLVPVVBGQByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateChiTietHSXLVPVVBGQ)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.ChiTietHSXLVPVVBGQs.Create)]
    public async Task<ActionResult<ApiResult<ChiTietHSXLVPVVBGQDto>>> CreateChiTietHSXLVPVVBGQ([FromBody] CreateChiTietHSXLVPVVBGQDto model)
    {
        var command = _mapper.Map<CreateChiTietHSXLVPVVBGQCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}", Name = RouteNames.UpdateChiTietHSXLVPVVBGQ)]
    [ProducesResponseType(typeof(ApiResult<ChiTietHSXLVPVVBGQDto>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.ChiTietHSXLVPVVBGQs.Edit)]
    public async Task<ActionResult<ApiResult<ChiTietHSXLVPVVBGQDto>>> UpdateChiTietHSXLVPVVBGQ([Required] int id, [FromBody] UpdateChiTietHSXLVPVVBGQCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}", Name = RouteNames.DeleteChiTietHSXLVPVVBGQ)]
    //[Authorize(Permissions.ChiTietHSXLVPVVBGQs.Delete)]
    public async Task<ActionResult<bool>> DeleteChiTietHSXLVPVVBGQ([Required] int id)
    {
        var command = new DeleteChiTietHSXLVPVVBGQCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}