using System.ComponentModel.DataAnnotations;
using System.Net;
using AutoMapper;
using CatalogService.Application.Common.Models.QuanHuyens;
using CatalogService.Application.Features.V1.QuanHuyens.Commands.CreateQuanHuyen;
using CatalogService.Application.Features.V1.QuanHuyens.Commands.DeleteQuanHuyen;
using CatalogService.Application.Features.V1.QuanHuyens.Commands.UpdateQuanHuyen;
using CatalogService.Application.Features.V1.QuanHuyens.Queries.GetQuanHuyenByTinhThanhPhoId;
using CatalogService.Application.Features.V1.QuanHuyens.Queries.GetQuanHuyens;
using CatalogService.Application.Parameters.QuanHuyens;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.SeedWord;

namespace CatalogService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuanHuyenController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public QuanHuyenController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        private static class RouteNames
        {
            public const string GetQuanHuyens = nameof(GetQuanHuyens);
            public const string GetQuanHuyenByTinhThanhPho = nameof(GetQuanHuyenByTinhThanhPho);
            public const string CreateQuanHuyen = nameof(CreateQuanHuyen);
            public const string UpdateQuanHuyen = nameof(UpdateQuanHuyen);
            public const string DeleteQuanHuyen = nameof(DeleteQuanHuyen);
            public const string GetQuanHuyenById = nameof(GetQuanHuyenById);
        }

        [HttpPost("paging", Name = RouteNames.GetQuanHuyens)]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<QuanHuyenDto>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PagedResponse<IEnumerable<QuanHuyenDto>>>> GetQuanHuyens([FromBody] QuanHuyenParameter request)
        {
            var query = new GetQuanHuyensQuery(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet(Name = RouteNames.GetQuanHuyenByTinhThanhPho)]
        [ProducesResponseType(typeof(IEnumerable<QuanHuyenDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<QuanHuyenDto>>> GetQuanHuyensByTerm([FromQuery] int tinhThanhPhoId)
        {
            var query = new GetQuanHuyenByTinhThanhPhoIdQuery(tinhThanhPhoId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost(Name = RouteNames.CreateQuanHuyen)]
        [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResult<QuanHuyenDto>>> CreateQuanHuyen([FromBody] CreateQuanHuyenDto model)
        {
            var command = _mapper.Map<CreateQuanHuyenCommand>(model);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id:int}", Name = RouteNames.UpdateQuanHuyen)]
        [ProducesResponseType(typeof(ApiResult<QuanHuyenDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResult<QuanHuyenDto>>> UpdateQuanHuyen([Required] int id, [FromBody] UpdateQuanHuyenCommand command)
        {
            command.SetId(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:int}", Name = RouteNames.DeleteQuanHuyen)]
        public async Task<ActionResult<bool>> DeleteQuanHuyen([Required] int id)
        {
            var command = new DeleteQuanHuyenCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}