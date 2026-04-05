using GeoMarker.Application.Features.Groups.Commands.AddMenber;
using GeoMarker.Application.Features.Groups.Commands.CreateGroup;
using GeoMarker.Application.Features.Groups.Commands.DeleteGroup;
using GeoMarker.Application.Features.Groups.Commands.RemoveMember;
using GeoMarker.Application.Features.Groups.Commands.UpdateGroup;
using GeoMarker.Application.Features.Groups.Queries.GetGroupsByMarkerId;
using GeoMarker.Application.Features.Groups.Queries.GetGroupsByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GeoMarker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly ISender _mediator;

        public GroupController(ISender mediator)
        {
            _mediator = mediator;
        }   

        [HttpPatch("{id}/desactivate")]
        public async Task<IActionResult> DesactivateGroup([FromBody] DeleteGroupCommand command)
        {
            var deleteCommand = new DeleteGroupCommand(
                OwnerId: command.OwnerId,
                GroupId: command.GroupId
                );
            var result = await _mediator.Send(deleteCommand);
            return NoContent();
        }

        [HttpPost("CreateGroup")]
        public async Task<IActionResult> CreateGroup(CreateGroupCommand command)
        {
            var result = await _mediator.Send(command);
            return Created($"api/group/{result.Id}", result);
        }

        [HttpPost("AddMember")]
        public async Task<IActionResult> AddMember(AddMemberCommand command)
        {
            var result = await _mediator.Send(command);
            return Created($"api/group/{result.GroupId}", result);
        }

        [HttpPatch("{id}/remove")]
        public async Task<IActionResult> RemoveMember( [FromBody] RemoveMemberCommand command)
        {
            var RemoveCommand = new RemoveMemberCommand(
                GroupeId: command.GroupeId,
                OwnerId: command.OwnerId,
                MemberId: command.MemberId
                );
            var result = await _mediator.Send(RemoveCommand);
            return NoContent();
        }

        [HttpPatch("{id}/updateGroup")]
        public async Task<IActionResult> UpdateGroup([FromBody] UpdateGroupCommand command)
        {
            var updateCommand = new UpdateGroupCommand(
                GroupId: command.GroupId,
                OwnerId: command.OwnerId,
                Name: command.Name,
                Description: command.Description
            );
            var result = await _mediator.Send(updateCommand);
            return NoContent();
        }

        [HttpGet("{id}/markers")]
        public async Task<IActionResult> GetGroupMarkers([FromQuery] GetGroupsByMarkerIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}/members")]
        public async Task<IActionResult> GetGroupMembers([FromQuery] GetGroupsByUserIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
