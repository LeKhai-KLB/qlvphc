using System.ComponentModel.DataAnnotations;
using System.Net;
using AutoMapper;
using CatalogService.Application.Common.Models.QuyetDinhXuPhats;
using CatalogService.Application.Features.V1.QuyetDinhXuPhats.Commands.CreateQuyetDinhXuPhat;
using CatalogService.Application.Features.V1.QuyetDinhXuPhats.Commands.DeleteQuyetDinhXuPhat;
using CatalogService.Application.Features.V1.QuyetDinhXuPhats.Commands.UpdateQuyetDinhXuPhat;
using CatalogService.Application.Features.V1.QuyetDinhXuPhats.Queries.GetQuyetDinhXuPhatByHoSoXuLyViPhamId;
using CatalogService.Application.Features.V1.QuyetDinhXuPhats.Queries.GetQuyetDinhXuPhats;
using CatalogService.Application.Parameters.QuyetDinhXuPhats;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.SeedWord;

namespace CatalogService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuyetDinhXuPhatController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public QuyetDinhXuPhatController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        private static class RouteNames
        {
            public const string GetQuyetDinhXuPhats = nameof(GetQuyetDinhXuPhats);
            public const string GetQuyetDinhXuPhatByHoSoXuLyViPham = nameof(GetQuyetDinhXuPhatByHoSoXuLyViPham);
            public const string CreateQuyetDinhXuPhat = nameof(CreateQuyetDinhXuPhat);
            public const string UpdateQuyetDinhXuPhat = nameof(UpdateQuyetDinhXuPhat);
            public const string DeleteQuyetDinhXuPhat = nameof(DeleteQuyetDinhXuPhat);
            public const string GetQuyetDinhXuPhatById = nameof(GetQuyetDinhXuPhatById);
        }

        [HttpPost("paging", Name = RouteNames.GetQuyetDinhXuPhats)]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<QuyetDinhXuPhatDto>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PagedResponse<IEnumerable<QuyetDinhXuPhatDto>>>> GetQuyetDinhXuPhats([FromBody] QuyetDinhXuPhatParameter request)
        {
            var query = new GetQuyetDinhXuPhatsQuery(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet(Name = RouteNames.GetQuyetDinhXuPhatByHoSoXuLyViPham)]
        [ProducesResponseType(typeof(IEnumerable<QuyetDinhXuPhatDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<QuyetDinhXuPhatDto>>> GetQuyetDinhXuPhatsByTerm([FromQuery] int hosoxulyviphamId)
        {
            var query = new GetQuyetDinhXuPhatByHoSoXuLyViPhamIdQuery(hosoxulyviphamId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost(Name = RouteNames.CreateQuyetDinhXuPhat)]
        [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResult<QuyetDinhXuPhatDto>>> CreateQuyetDinhXuPhat([FromBody] CreateQuyetDinhXuPhatDto model)
        {
            var command = _mapper.Map<CreateQuyetDinhXuPhatCommand>(model);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id:int}", Name = RouteNames.UpdateQuyetDinhXuPhat)]
        [ProducesResponseType(typeof(ApiResult<QuyetDinhXuPhatDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResult<QuyetDinhXuPhatDto>>> UpdateQuyetDinhXuPhat([Required] int id, [FromBody] UpdateQuyetDinhXuPhatCommand command)
        {
            command.SetId(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:int}", Name = RouteNames.DeleteQuyetDinhXuPhat)]
        public async Task<ActionResult<bool>> DeleteQuyetDinhXuPhat([Required] int id)
        {
            var command = new DeleteQuyetDinhXuPhatCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}