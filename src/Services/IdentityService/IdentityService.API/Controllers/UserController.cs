using AutoMapper;
using IdentityService.Application.Common.Interfaces;
using IdentityService.Application.Features.V1.Users.Commands.CreateUser;
using IdentityService.Application.Features.V1.Users.Commands.DeleteUser;
using IdentityService.Application.Features.V1.Users.Commands.UpdateUser;
using IdentityService.Application.Features.V1.Users.Queries.GetUserbyId;
using IdentityService.Application.Features.V1.Users.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Common.Constants;

namespace IdentityService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _auth;
        private readonly IMediator _mediator;

        public UserController(IMediator mediator, IMapper mapper, IAuthService authService)
        {
            _mapper = mapper;
            _auth = authService;
            _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        }

        // GET: api/Users
        [HttpGet]
        [Authorize(Permissions.Users.SuperAdminView)]
        public async Task<IActionResult> GetUsers()
        {
            var query = new GetUsersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        [Authorize(Permissions.Users.ViewById)]
        public async Task<IActionResult> GetUserbyId(string id)
        {
            var query = new GetUserbyIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // PUT: api/Users/5
        [Authorize(Permissions.Users.Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, UpdateUserCommand command)
        {
            command.SetId(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // POST: api/Users
        [Authorize(Permissions.Users.Create)]
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] CreateUserCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }

            return BadRequest("Some properties are not valid"); // Status code: 400
        }

        // DELETE: api/Users/5
        [Authorize(Permissions.Users.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}