using BookReviewManager.Application.Commands.LoginCommand;
using BookReviewManager.Application.Commands.UserCommands.CreateUser;
using BookReviewManager.Application.Commands.UserCommands.DeleteUsers;
using BookReviewManager.Application.Commands.UserCommands.UpdateUser;
using BookReviewManager.Application.Queries;
using BookReviewManager.Application.Queries.UserQueries.GetAllUsers;
using BookReviewManager.Infrastructure.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewManager.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthService _authService;

        public UsersController(IMediator mediator, IAuthService authService)
        {
            _mediator = mediator;
            _authService = authService;
        }

        // GET api/users
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        // GET api/users/123
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        // POST api/users
        [HttpPost]
        //[AllowAnonymous]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            var hash = _authService.ComputeHash(command.Password);
            command.Password = hash;
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Data },
                command);
        }

        // PUT api/users/123
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        // DELETE api/users/123
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
        [HttpPut("login")]
        //[AllowAnonymous]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
