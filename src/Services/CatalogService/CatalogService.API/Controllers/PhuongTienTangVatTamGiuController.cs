using System.ComponentModel.DataAnnotations;
using System.Net;
using AutoMapper;
using CatalogService.Application.Common.Models.TangVatPhuongTienTamGius;
using CatalogService.Application.Features.V1.TangVatPhuongTienTamGius.Commands.CreateTangVatPhuongTienTamGiu;
using CatalogService.Application.Features.V1.TangVatPhuongTienTamGius.Commands.DeleteTangVatPhuongTienTamGiu;
using CatalogService.Application.Features.V1.TangVatPhuongTienTamGius.Commands.UpdateTangVatPhuongTienTamGiu;
using CatalogService.Application.Features.V1.TangVatPhuongTienTamGius.Queries.GetTangVatPhuongTienTamGiuByHoSoXuLyViPhamId;
using CatalogService.Application.Features.V1.TangVatPhuongTienTamGius.Queries.GetTangVatPhuongTienTamGius;
using CatalogService.Application.Parameters.TangVatPhuongTienTamGius;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.SeedWord;

namespace CatalogService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TangVatPhuongTienTamGiuController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TangVatPhuongTienTamGiuController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        private static class RouteNames
        {
            public const string GetTangVatPhuongTienTamGius = nameof(GetTangVatPhuongTienTamGius);
            public const string GetTangVatPhuongTienTamGiuByHoSoXuLyViPham = nameof(GetTangVatPhuongTienTamGiuByHoSoXuLyViPham);
            public const string CreateTangVatPhuongTienTamGiu = nameof(CreateTangVatPhuongTienTamGiu);
            public const string UpdateTangVatPhuongTienTamGiu = nameof(UpdateTangVatPhuongTienTamGiu);
            public const string DeleteTangVatPhuongTienTamGiu = nameof(DeleteTangVatPhuongTienTamGiu);
            public const string GetTangVatPhuongTienTamGiuById = nameof(GetTangVatPhuongTienTamGiuById);
        }

        [HttpPost("paging", Name = RouteNames.GetTangVatPhuongTienTamGius)]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<TangVatPhuongTienTamGiuDto>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PagedResponse<IEnumerable<TangVatPhuongTienTamGiuDto>>>> GetTangVatPhuongTienTamGius([FromBody] TangVatPhuongTienTamGiuParameter request)
        {
            var query = new GetTangVatPhuongTienTamGiusQuery(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet(Name = RouteNames.GetTangVatPhuongTienTamGiuByHoSoXuLyViPham)]
        [ProducesResponseType(typeof(IEnumerable<TangVatPhuongTienTamGiuDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TangVatPhuongTienTamGiuDto>>> GetTangVatPhuongTienTamGiusByTerm([FromQuery] int hosoxulyviphamId)
        {
            var query = new GetTangVatPhuongTienTamGiuByHoSoXuLyViPhamIdQuery(hosoxulyviphamId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost(Name = RouteNames.CreateTangVatPhuongTienTamGiu)]
        [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResult<TangVatPhuongTienTamGiuDto>>> CreateTangVatPhuongTienTamGiu([FromBody] CreateTangVatPhuongTienTamGiuDto model)
        {
            var command = _mapper.Map<CreateTangVatPhuongTienTamGiuCommand>(model);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id:int}", Name = RouteNames.UpdateTangVatPhuongTienTamGiu)]
        [ProducesResponseType(typeof(ApiResult<TangVatPhuongTienTamGiuDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResult<TangVatPhuongTienTamGiuDto>>> UpdateTangVatPhuongTienTamGiu([Required] int id, [FromBody] UpdateTangVatPhuongTienTamGiuCommand command)
        {
            command.SetId(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:int}", Name = RouteNames.DeleteTangVatPhuongTienTamGiu)]
        public async Task<ActionResult<bool>> DeleteTangVatPhuongTienTamGiu([Required] int id)
        {
            var command = new DeleteTangVatPhuongTienTamGiuCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}