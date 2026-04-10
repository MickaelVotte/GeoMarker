using GeoMarker.Application.Features.Users.Commands.DesactiveUser;
using GeoMarker.Application.Features.Users.Commands.UpdateUser;
using GeoMarker.Application.Features.Users.DTOs;
using GeoMarker.Application.Features.Users.Queries.GetUserMarker;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GeoMarker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ApiController
    {
        private readonly ISender _mediator;

        public UserController(ISender mediator)
        {
            _mediator = mediator;

        }
        [Authorize]
        [HttpPatch("/desactivate")]
        public async Task<IActionResult> DesactivateUser()
        {
            var deletecommand = new DesactiveUserCommand(
                Id: CurrentUserId
                );
            var result = await _mediator.Send(deletecommand);
            return NoContent();

        }

        [Authorize]
        [HttpPatch("/update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            var updateCommand = new UpdateUserCommand(
                Id: CurrentUserId,
                Firstname: command.Firstname,
                Lastname: command.Lastname,
                Email: command.Email,
                Password: command.Password
            );

            var result = await _mediator.Send(updateCommand);
            return NoContent();
        }

        [Authorize]
        [HttpGet("/markers")]
        public async Task<IActionResult> GetUserMarkers()
        {
            var userIdFromToken = CurrentUserId;
            var query = new GetUserMarkersQuery(userIdFromToken);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}