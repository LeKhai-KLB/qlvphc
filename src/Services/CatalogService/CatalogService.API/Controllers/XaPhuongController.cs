using System.ComponentModel.DataAnnotations;
using System.Net;
using AutoMapper;
using CatalogService.Application.Common.Models.XaPhuongs;
using CatalogService.Application.Features.V1.XaPhuongs.Commands.CreateXaPhuong;
using CatalogService.Application.Features.V1.XaPhuongs.Commands.DeleteXaPhuong;
using CatalogService.Application.Features.V1.XaPhuongs.Commands.UpdateXaPhuong;
using CatalogService.Application.Features.V1.XaPhuongs.Queries.GetXaPhuongByQuanHuyenId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.SeedWord;

namespace CatalogService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class XaPhuongController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public XaPhuongController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        private static class RouteNames
        {
            public const string GetXaPhuongs = nameof(GetXaPhuongs);
            public const string GetXaPhuongByQuanHuyen = nameof(GetXaPhuongByQuanHuyen);
            public const string CreateXaPhuong = nameof(CreateXaPhuong);
            public const string UpdateXaPhuong = nameof(UpdateXaPhuong);
            public const string DeleteXaPhuong = nameof(DeleteXaPhuong);
            public const string GetXaPhuongById = nameof(GetXaPhuongById);
        }

        [HttpGet(Name = RouteNames.GetXaPhuongByQuanHuyen)]
        [ProducesResponseType(typeof(IEnumerable<XaPhuongDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<XaPhuongDto>>> GetXaPhuongsByTerm([FromQuery] int quanHuyenId)
        {
            var query = new GetXaPhuongByQuanHuyenIdQuery(quanHuyenId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost(Name = RouteNames.CreateXaPhuong)]
        [ProducesResponseType(typeof(ApiResult<int>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResult<XaPhuongDto>>> CreateXaPhuong([FromBody] CreateXaPhuongDto model)
        {
            var command = _mapper.Map<CreateXaPhuongCommand>(model);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id:int}", Name = RouteNames.UpdateXaPhuong)]
        [ProducesResponseType(typeof(ApiResult<XaPhuongDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResult<XaPhuongDto>>> UpdateXaPhuong([Required] int id, [FromBody] UpdateXaPhuongCommand command)
        {
            command.SetId(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:int}", Name = RouteNames.DeleteXaPhuong)]
        public async Task<ActionResult<bool>> DeleteXaPhuong([Required] int id)
        {
            var command = new DeleteXaPhuongCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}