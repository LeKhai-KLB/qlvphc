using AutoMapper;
using CatalogService.Application.Common.Models.KetQuaXuPhatTruyCuuHSs;
using CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Commands.CreateKetQuaXuPhatTruyCuuHS;
using CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Commands.DeleteKetQuaXuPhatTruyCuuHS;
using CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Commands.UpdateKetQuaXuPhatTruyCuuHS;
using CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Queries.GetAllKetQuaXuPhatTruyCuuHSs;
using CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Queries.GetKetQuaXuPhatTruyCuuHSById;
using CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Queries.GetPagedKetQuaXuPhatTruyCuuHS;
using CatalogService.Application.Parameters.KetQuaXuPhatTruyCuuHSs;
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
public class KetQuaXuPhatTruyCuuHSController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public KetQuaXuPhatTruyCuuHSController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    private static class RouteNames
    {
        public const string GetPagedKetQuaXuPhatTruyCuuHS = nameof(GetPagedKetQuaXuPhatTruyCuuHS);
        public const string GetAllKetQuaXuPhatTruyCuuHSs = nameof(GetAllKetQuaXuPhatTruyCuuHSs);
        public const string GetKetQuaXuPhatTruyCuuHSById = nameof(GetKetQuaXuPhatTruyCuuHSById);
        public const string CreateKetQuaXuPhatTruyCuuHS = nameof(CreateKetQuaXuPhatTruyCuuHS);
        public const string UpdateKetQuaXuPhatTruyCuuHS = nameof(UpdateKetQuaXuPhatTruyCuuHS);
        public const string DeleteKetQuaXuPhatTruyCuuHS = nameof(DeleteKetQuaXuPhatTruyCuuHS);
    }

    [HttpPost("paging", Name = RouteNames.GetPagedKetQuaXuPhatTruyCuuHS)]
    [ProducesResponseType(typeof(PagedResponse<IEnumerable<KetQuaXuPhatTruyCuuHSDto>>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.KetQuaXuPhatTruyCuuHSs.View)]
    public async Task<ActionResult<PagedResponse<IEnumerable<KetQuaXuPhatTruyCuuHSDto>>>> GetPagedLinhVucXuPhat([FromBody] KetQuaXuPhatTruyCuuHSParameter request)
    {
        var query = new GetPagedKetQuaXuPhatTruyCuuHSQuery(request);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetAllKetQuaXuPhatTruyCuuHSs)]
    [ProducesResponseType(typeof(IEnumerable<KetQuaXuPhatTruyCuuHSDto>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.KetQuaXuPhatTruyCuuHSs.View)]
    public async Task<ActionResult<IEnumerable<KetQuaXuPhatTruyCuuHSDto>>> GetAllKetQuaXuPhatTruyCuuHSs()
    {
        var query = new GetAllKetQuaXuPhatTruyCuuHSsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route(RouteNames.GetKetQuaXuPhatTruyCuuHSById)]
    [ProducesResponseType(typeof(KetQuaXuPhatTruyCuuHSDto), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.KetQuaXuPhatTruyCuuHSs.ViewById)]
    public async Task<ActionResult<KetQuaXuPhatTruyCuuHSDto>> GetKetQuaXuPhatTruyCuuHSById([FromQuery] int id)
    {
        var query = new GetKetQuaXuPhatTruyCuuHSByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Name = RouteNames.CreateKetQuaXuPhatTruyCuuHS)]
    [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.KetQuaXuPhatTruyCuuHSs.Create)]
    public async Task<ActionResult<ApiResult<KetQuaXuPhatTruyCuuHSDto>>> CreateKetQuaXuPhatTruyCuuHS([FromBody] CreateKetQuaXuPhatTruyCuuHSDto model)
    {
        var command = _mapper.Map<CreateKetQuaXuPhatTruyCuuHSCommand>(model);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}", Name = RouteNames.UpdateKetQuaXuPhatTruyCuuHS)]
    [ProducesResponseType(typeof(ApiResult<KetQuaXuPhatTruyCuuHSDto>), (int)HttpStatusCode.OK)]
    //[Authorize(Permissions.KetQuaXuPhatTruyCuuHSs.Edit)]
    public async Task<ActionResult<ApiResult<KetQuaXuPhatTruyCuuHSDto>>> UpdateKetQuaXuPhatTruyCuuHS([Required] int id, [FromBody] UpdateKetQuaXuPhatTruyCuuHSCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}", Name = RouteNames.DeleteKetQuaXuPhatTruyCuuHS)]
    //[Authorize(Permissions.KetQuaXuPhatTruyCuuHSs.Delete)]
    public async Task<ActionResult<bool>> DeleteKetQuaXuPhatTruyCuuHS([Required] int id)
    {
        var command = new DeleteKetQuaXuPhatTruyCuuHSCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}