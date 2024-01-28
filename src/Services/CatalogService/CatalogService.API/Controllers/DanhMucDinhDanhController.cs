using System.ComponentModel.DataAnnotations;
using System.Net;
using AutoMapper;
using CatalogService.Application.Common.Models.DanhMucDinhDanhs;
using CatalogService.Application.Features.V1.DanhMucDinhDanhs.Commands.CreateDanhMucDinhDanh;
using CatalogService.Application.Features.V1.DanhMucDinhDanhs.Commands.DeleteDanhMucDinhDanh;
using CatalogService.Application.Features.V1.DanhMucDinhDanhs.Commands.UpdateDanhMucDinhDanh;
using CatalogService.Application.Features.V1.DanhMucDinhDanhs.Queries.GetDanhMucDinhDanhById;
using CatalogService.Application.Features.V1.DanhMucDinhDanhs.Queries.GetDanhMucDinhDanhs;
using CatalogService.Application.Features.V1.DanhMucDinhDanhs.Queries.GetDanhMucDinhDanhsByTerm;
using CatalogService.Application.Parameters.DanhMucDinhDanhs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.SeedWord;

namespace CatalogService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DanhMucDinhDanhController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DanhMucDinhDanhController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        private static class RouteNames
        {
            public const string GetDanhMucDinhDanhs = nameof(GetDanhMucDinhDanhs);
            public const string GetAllDanhMucDinhDanhs = nameof(GetAllDanhMucDinhDanhs);
            public const string CreateDanhMucDinhDanh = nameof(CreateDanhMucDinhDanh);
            public const string UpdateDanhMucDinhDanh = nameof(UpdateDanhMucDinhDanh);
            public const string DeleteDanhMucDinhDanh = nameof(DeleteDanhMucDinhDanh);
            public const string GetDanhMucDinhDanhById = nameof(GetDanhMucDinhDanhById);
        }

        [HttpPost("paging", Name = RouteNames.GetDanhMucDinhDanhs)]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<DanhMucDinhDanhDto>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PagedResponse<IEnumerable<DanhMucDinhDanhDto>>>> GetDanhMucDinhDanhs([FromBody] DanhMucDinhDanhParameter request)
        {
            var query = new GetDanhMucDinhDanhsQuery(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet(Name = RouteNames.GetAllDanhMucDinhDanhs)]
        [ProducesResponseType(typeof(IEnumerable<DanhMucDinhDanhDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<DanhMucDinhDanhDto>>> GetDanhMucDinhDanhsByTerm([FromQuery] string? term)
        {
            var query = new GetDanhMucDinhDanhsByTermQuery(term);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id:int}", Name = RouteNames.GetDanhMucDinhDanhById)]
        [ProducesResponseType(typeof(DanhMucDinhDanhDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<DanhMucDinhDanhDto>> GetDanhMucDinhDanhById([Required] int id)
        {
            var query = new GetDanhMucDinhDanhByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost(Name = RouteNames.CreateDanhMucDinhDanh)]
        [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResult<DanhMucDinhDanhDto>>> CreateDanhMucDinhDanh([FromBody] CreateDanhMucDinhDanhDto model)
        {
            var command = _mapper.Map<CreateDanhMucDinhDanhCommand>(model);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id:int}", Name = RouteNames.UpdateDanhMucDinhDanh)]
        [ProducesResponseType(typeof(ApiResult<DanhMucDinhDanhDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResult<DanhMucDinhDanhDto>>> UpdateDanhMucDinhDanh([Required] int id, [FromBody] UpdateDanhMucDinhDanhCommand command)
        {
            command.SetId(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:int}", Name = RouteNames.DeleteDanhMucDinhDanh)]
        public async Task<ActionResult<bool>> DeleteDanhMucDinhDanh([Required] int id)
        {
            var command = new DeleteDanhMucDinhDanhCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}