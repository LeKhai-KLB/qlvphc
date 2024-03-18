using AutoMapper;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Shared.SeedWord;
using CatalogService.Application.Common.Models.HinhThucXuPhatBoSungs;
using CatalogService.Application.Features.V1.HinhThucXuPhatBoSungs.Commands.DeleteHinhThucXuPhatBoSung;
using CatalogService.Application.Features.V1.HinhThucXuPhatBoSungs.Commands.UpdateHinhThucXuPhatBoSung;
using CatalogService.Application.Features.V1.HinhThucXuPhatBoSungs.Commands.CreateHinhThucXuPhatBoSung;
using CatalogService.Application.Features.V1.HinhThucXuPhatBoSungs.Queries.GetHinhThucXuPhatBoSungById;
using Microsoft.AspNetCore.Authorization;
using CatalogService.Application.Features.V1.HinhThucXuPhatBoSungs.Queries.GetHinhThucXuPhatBoSungs;

namespace CatalogService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize(AuthenticationSchemes = "Bearer")]
public class HinhThucXuPhatBoSungController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public HinhThucXuPhatBoSungController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetAllHinhThucXuPhatBoSung = nameof(GetAllHinhThucXuPhatBoSung);
        public const string GetHinhThucXuPhatBoSungById = nameof(GetHinhThucXuPhatBoSungById);
        public const string CreateHinhThucXuPhatBoSung = nameof(CreateHinhThucXuPhatBoSung);
        public const string UpdateHinhThucXuPhatBoSung = nameof(UpdateHinhThucXuPhatBoSung);
        public const string DeleteHinhThucXuPhatBoSung = nameof(DeleteHinhThucXuPhatBoSung);
    }

    [HttpGet]
    [Route(RouteNames.GetAllHinhThucXuPhatBoSung)]
    [ProducesResponseType(typeof(IEnumerable<HinhThucXuPhatBoSungDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<HinhThucXuPhatBoSungDto>>> GetAllHinhThucXuPhatBoSung()
    {
        var query = new GetHinhThucXuPhatBoSungsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetHinhThucXuPhatBoSungById)]
    [ProducesResponseType(typeof(HinhThucXuPhatBoSungDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<HinhThucXuPhatBoSungDto>> GetHinhThucXuPhatBoSungById([FromQuery] int id)
    {
        var query = new GetHinhThucXuPhatBoSungByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateHinhThucXuPhatBoSung)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ApiResult<HinhThucXuPhatBoSungDto>>> CreateHinhThucXuPhatBoSung([FromBody] CreateHinhThucXuPhatBoSungDto model)
    {
        var command = _mapper.Map<CreateHinhThucXuPhatBoSungCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}", Name = RouteNames.UpdateHinhThucXuPhatBoSung)]
    [ProducesResponseType(typeof(ApiResult<HinhThucXuPhatBoSungDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ApiResult<HinhThucXuPhatBoSungDto>>> UpdateHinhThucXuPhatBoSung([Required] int id, [FromBody] UpdateHinhThucXuPhatBoSungCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}", Name = RouteNames.DeleteHinhThucXuPhatBoSung)]
    public async Task<ActionResult<bool>> DeleteHinhThucXuPhatBoSung([Required] int id)
    {
        var command = new DeleteHinhThucXuPhatBoSungCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}