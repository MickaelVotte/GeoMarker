using GeoMarker.Application.Features.Markers.Commands.AddMarker;
using GeoMarker.Application.Features.Markers.Commands.DeleteMarker;
using GeoMarker.Application.Features.Markers.Commands.UpdateMarker;
using GeoMarker.Application.Features.Markers.Queries.GetMarkersByLocation;
using GeoMarker.Application.Features.Markers.Queries.GetMarkersByUserId;
using GeoMarker.Application.Features.Markers.Queries.SearchMarkers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeoMarker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarkerController : ControllerBase
    {

        private readonly ISender _mediator;

        public MarkerController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPatch("{id}/desactivate")]
        public async Task<IActionResult> DeleteMarker([FromBody] DeleteMarkerCommand command)
        {
            var deleteCommand = new DeleteMarkerCommand(
                Id: command.Id,
                UserId: command.UserId
            );
            var result = await _mediator.Send(deleteCommand);
            return NoContent();
        }

        [HttpPost("addMarker")]
        public async Task<IActionResult> AddMarker(AddMarkerCommand command)
        {
            var result = await _mediator.Send(command);
            return Created($"api/marker/{result.Id}", result);
        }

        [HttpPatch("{id}/updateMarker")]
        public async Task<IActionResult> UpdateMarker([FromBody] UpdateMarkerCommand command)
        {
            var updateCommand = new UpdateMarkerCommand(
                Id: command.Id,
                Title: command.Title,
                Description: command.Description,
                Latitude: command.Latitude,
                Longitude: command.Longitude,
                UserId: command.UserId
            );
            var result = await _mediator.Send(updateCommand);
            return NoContent();
        }

        [HttpGet("location")]
        public async Task<IActionResult> GetMarkerLocation([FromQuery] GetMarkersByLocationQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("userId")]
        public async Task<IActionResult> GetMarkerByUserId([FromQuery] GetMarkersByUserIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchMarkers([FromQuery] SearchMarkersQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}