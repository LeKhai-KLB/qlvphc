using System.ComponentModel.DataAnnotations;
using System.Net;
using AutoMapper;
using CatalogService.Application.Common.Models.TinhThanhPhos;
using CatalogService.Application.Features.V1.TinhThanhPhos.Commands.CreateTinhThanhPho;
using CatalogService.Application.Features.V1.TinhThanhPhos.Commands.DeleteTinhThanhPho;
using CatalogService.Application.Features.V1.TinhThanhPhos.Commands.UpdateTinhThanhPho;
using CatalogService.Application.Features.V1.TinhThanhPhos.Queries.GetTinhThanhPhoById;
using CatalogService.Application.Features.V1.TinhThanhPhos.Queries.GetTinhThanhPhos;
using CatalogService.Application.Features.V1.TinhThanhPhos.Queries.GetTinhThanhPhosByTerm;
using CatalogService.Application.Parameters.TinhThanhPhos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.SeedWord;

namespace CatalogService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TinhThanhPhoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TinhThanhPhoController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        private static class RouteNames
        {
            public const string GetTinhThanhPhos = nameof(GetTinhThanhPhos);
            public const string GetAllTinhThanhPhos = nameof(GetAllTinhThanhPhos);
            public const string CreateTinhThanhPho = nameof(CreateTinhThanhPho);
            public const string UpdateTinhThanhPho = nameof(UpdateTinhThanhPho);
            public const string DeleteTinhThanhPho = nameof(DeleteTinhThanhPho);
            public const string GetTinhThanhPhoById = nameof(GetTinhThanhPhoById);
        }

        [HttpPost("paging", Name = RouteNames.GetTinhThanhPhos)]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<TinhThanhPhoDto>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PagedResponse<IEnumerable<TinhThanhPhoDto>>>> GetTinhThanhPhos([FromBody] TinhThanhPhoParameter request)
        {
            var query = new GetTinhThanhPhosQuery(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet(Name = RouteNames.GetAllTinhThanhPhos)]
        [ProducesResponseType(typeof(IEnumerable<TinhThanhPhoDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TinhThanhPhoDto>>> GetTinhThanhPhosByTerm([FromQuery] string? term)
        {
            var query = new GetTinhThanhPhosByTermQuery(term);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id:int}", Name = RouteNames.GetTinhThanhPhoById)]
        [ProducesResponseType(typeof(TinhThanhPhoDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TinhThanhPhoDto>> GetTinhThanhPhoById([Required] int id)
        {
            var query = new GetTinhThanhPhoByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost(Name = RouteNames.CreateTinhThanhPho)]
        [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResult<TinhThanhPhoDto>>> CreateTinhThanhPho([FromBody] CreateTinhThanhPhoDto model)
        {
            var command = _mapper.Map<CreateTinhThanhPhoCommand>(model);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id:int}", Name = RouteNames.UpdateTinhThanhPho)]
        [ProducesResponseType(typeof(ApiResult<TinhThanhPhoDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResult<TinhThanhPhoDto>>> UpdateTinhThanhPho([Required] int id, [FromBody] UpdateTinhThanhPhoCommand command)
        {
            command.SetId(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:int}", Name = RouteNames.DeleteTinhThanhPho)]
        public async Task<ActionResult<bool>> DeleteTinhThanhPho([Required] int id)
        {
            var command = new DeleteTinhThanhPhoCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}