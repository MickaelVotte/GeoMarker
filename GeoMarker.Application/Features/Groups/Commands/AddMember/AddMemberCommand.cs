using GeoMarker.Application.Features.Groups.DTOs;
using MediatR;

namespace GeoMarker.Application.Features.Groups.Commands.AddMenber
{
    public record AddMemberCommand
    (
        Guid OwnerId,
        Guid MemberId,
        Guid GroupId
    ) : IRequest<AddMemberResponse>;
}
