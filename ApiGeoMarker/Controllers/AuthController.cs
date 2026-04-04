using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeoMarker.Application.Features.Users.Commands.CreateUser;
using MediatR;
using GeoMarker.Application.Features.Users.Commands.LoginUser;



namespace GeoMarker.Api.Controllers
{

    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {

        private readonly ISender _mediator;

        public AuthController(ISender mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);

        }
    }
}
