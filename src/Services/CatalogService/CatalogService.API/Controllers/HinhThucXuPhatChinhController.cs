using AutoMapper;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Shared.SeedWord;
using CatalogService.Application.Common.Models.HinhThucXuPhatChinhs;
using CatalogService.Application.Features.V1.HinhThucXuPhatChinhs.Commands.DeleteHinhThucXuPhatChinh;
using CatalogService.Application.Features.V1.HinhThucXuPhatChinhs.Commands.UpdateHinhThucXuPhatChinh;
using CatalogService.Application.Features.V1.HinhThucXuPhatChinhs.Commands.CreateHinhThucXuPhatChinh;
using CatalogService.Application.Features.V1.HinhThucXuPhatChinhs.Queries.GetHinhThucXuPhatChinhById;
using Microsoft.AspNetCore.Authorization;
using CatalogService.Application.Features.V1.HinhThucXuPhatChinhs.Queries.GetHinhThucXuPhatChinhs;

namespace CatalogService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class HinhThucXuPhatChinhController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public HinhThucXuPhatChinhController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetAllHinhThucXuPhatChinh = nameof(GetAllHinhThucXuPhatChinh);
        public const string GetHinhThucXuPhatChinhById = nameof(GetHinhThucXuPhatChinhById);
        public const string CreateHinhThucXuPhatChinh = nameof(CreateHinhThucXuPhatChinh);
        public const string UpdateHinhThucXuPhatChinh = nameof(UpdateHinhThucXuPhatChinh);
        public const string DeleteHinhThucXuPhatChinh = nameof(DeleteHinhThucXuPhatChinh);
    }

    [HttpGet]
    [Route(RouteNames.GetAllHinhThucXuPhatChinh)]
    [ProducesResponseType(typeof(IEnumerable<HinhThucXuPhatChinhDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<HinhThucXuPhatChinhDto>>> GetAllHinhThucXuPhatChinh()
    {
        var query = new GetHinhThucXuPhatChinhsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetHinhThucXuPhatChinhById)]
    [ProducesResponseType(typeof(HinhThucXuPhatChinhDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<HinhThucXuPhatChinhDto>> GetHinhThucXuPhatChinhById([FromQuery] int id)
    {
        var query = new GetHinhThucXuPhatChinhByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateHinhThucXuPhatChinh)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ApiResult<HinhThucXuPhatChinhDto>>> CreateHinhThucXuPhatChinh([FromBody] CreateHinhThucXuPhatChinhDto model)
    {
        var command = _mapper.Map<CreateHinhThucXuPhatChinhCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}", Name = RouteNames.UpdateHinhThucXuPhatChinh)]
    [ProducesResponseType(typeof(ApiResult<HinhThucXuPhatChinhDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ApiResult<HinhThucXuPhatChinhDto>>> UpdateHinhThucXuPhatChinh([Required] int id, [FromBody] UpdateHinhThucXuPhatChinhCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}", Name = RouteNames.DeleteHinhThucXuPhatChinh)]
    public async Task<ActionResult<bool>> DeleteHinhThucXuPhatChinh([Required] int id)
    {
        var command = new DeleteHinhThucXuPhatChinhCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}