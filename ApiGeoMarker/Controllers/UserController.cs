using GeoMarker.Application.Features.Users.Commands.DesactiveUser;
using GeoMarker.Application.Features.Users.Commands.UpdateUser;
using GeoMarker.Application.Features.Users.DTOs;
using GeoMarker.Application.Features.Users.Queries.GetUserMarker;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeoMarker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ISender _mediator;

        public UserController(ISender mediator)
        {
            _mediator = mediator;

        }

        [HttpPatch("{id}/desactivate")]
        public async Task<IActionResult> DesactivateUser(DesactiveUserCommand command)
        {
            var deletecommand = new DesactiveUserCommand(
                Id: command.Id
                );
            var result = await _mediator.Send(deletecommand);
            return NoContent();

        }

        [HttpPatch("{id}/update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            var updateCommand = new UpdateUserCommand(
                Id: command.Id,
                Firstname: command.Firstname,
                Lastname: command.Lastname,
                Email: command.Email,
                Password: command.Password
            );

            var result = await _mediator.Send(updateCommand);
            return NoContent();
        }

        [HttpGet("{id}/markers")]
        public async Task<IActionResult> GetUserMarkers([FromQuery]GetUserMarkersQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}