using System.ComponentModel.DataAnnotations;
using System.Net;
using AutoMapper;
using CatalogService.Application.Common.Models.GiayPhepTamGius;
using CatalogService.Application.Features.V1.GiayPhepTamGius.Commands.CreateGiayPhepTamGiu;
using CatalogService.Application.Features.V1.GiayPhepTamGius.Commands.DeleteGiayPhepTamGiu;
using CatalogService.Application.Features.V1.GiayPhepTamGius.Commands.UpdateGiayPhepTamGiu;
using CatalogService.Application.Features.V1.GiayPhepTamGius.Queries.GetGiayPhepTamGiuByHoSoXuLyViPhamId;
using CatalogService.Application.Features.V1.GiayPhepTamGius.Queries.GetGiayPhepTamGius;
using CatalogService.Application.Parameters.GiayPhepTamGius;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.SeedWord;

namespace CatalogService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GiayPhepTamGiuController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GiayPhepTamGiuController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        private static class RouteNames
        {
            public const string GetGiayPhepTamGius = nameof(GetGiayPhepTamGius);
            public const string GetGiayPhepTamGiuByHoSoXuLyViPham = nameof(GetGiayPhepTamGiuByHoSoXuLyViPham);
            public const string CreateGiayPhepTamGiu = nameof(CreateGiayPhepTamGiu);
            public const string UpdateGiayPhepTamGiu = nameof(UpdateGiayPhepTamGiu);
            public const string DeleteGiayPhepTamGiu = nameof(DeleteGiayPhepTamGiu);
            public const string GetGiayPhepTamGiuById = nameof(GetGiayPhepTamGiuById);
        }

        [HttpPost("paging", Name = RouteNames.GetGiayPhepTamGius)]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<GiayPhepTamGiuDto>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PagedResponse<IEnumerable<GiayPhepTamGiuDto>>>> GetGiayPhepTamGius([FromBody] GiayPhepTamGiuParameter request)
        {
            var query = new GetGiayPhepTamGiusQuery(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet(Name = RouteNames.GetGiayPhepTamGiuByHoSoXuLyViPham)]
        [ProducesResponseType(typeof(IEnumerable<GiayPhepTamGiuDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GiayPhepTamGiuDto>>> GetGiayPhepTamGiusByTerm([FromQuery] int hosoxulyviphamId)
        {
            var query = new GetGiayPhepTamGiuByHoSoXuLyViPhamIdQuery(hosoxulyviphamId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost(Name = RouteNames.CreateGiayPhepTamGiu)]
        [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResult<GiayPhepTamGiuDto>>> CreateGiayPhepTamGiu([FromBody] CreateGiayPhepTamGiuDto model)
        {
            var command = _mapper.Map<CreateGiayPhepTamGiuCommand>(model);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id:int}", Name = RouteNames.UpdateGiayPhepTamGiu)]
        [ProducesResponseType(typeof(ApiResult<GiayPhepTamGiuDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResult<GiayPhepTamGiuDto>>> UpdateGiayPhepTamGiu([Required] int id, [FromBody] UpdateGiayPhepTamGiuCommand command)
        {
            command.SetId(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:int}", Name = RouteNames.DeleteGiayPhepTamGiu)]
        public async Task<ActionResult<bool>> DeleteGiayPhepTamGiu([Required] int id)
        {
            var command = new DeleteGiayPhepTamGiuCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}