using GeoMarker.Application.Features.Groups.DTOs;
using MediatR;

namespace GeoMarker.Application.Features.Groups.Commands.CreateGroup
{
    public record CreateGroupCommand
    (
       string Name,
       string? Description,
       Guid OwnerId
    ): IRequest<CreateGroupResponse>;
}
