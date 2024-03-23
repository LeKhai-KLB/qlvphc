using AutoMapper;
using CatalogService.Application.Common.Models.KhoBacs;
using CatalogService.Application.Features.V1.KhoBacs.Queries.GetAllKhoBacs;
using CatalogService.Application.Features.V1.KhoBacs.Queries.GetPagedKhoBac;
using CatalogService.Application.Parameters.KhoBacs;
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
public class KhoBacController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public KhoBacController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetPagedKhoBac = nameof(GetPagedKhoBac);
        public const string GetAllKhoBacs = nameof(GetAllKhoBacs);
    }

    [HttpPost("paging", Name = RouteNames.GetPagedKhoBac)]
    [ProducesResponseType(typeof(PagedResponse<IEnumerable<KhoBacDto>>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.KhoBacs.View)]
    public async Task<ActionResult<PagedResponse<IEnumerable<KhoBacDto>>>> GetPagedLinhVucXuPhat([FromBody] KhoBacParameter request)
    {
        var query = new GetPagedKhoBacQuery(request);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetAllKhoBacs)]
    [ProducesResponseType(typeof(IEnumerable<KhoBacDto>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.KhoBacs.View)]
    public async Task<ActionResult<IEnumerable<KhoBacDto>>> GetAllKhoBacs()
    {
        var query = new GetAllKhoBacsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}