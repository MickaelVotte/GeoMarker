using GeoMarker.Application.Features.Groups.DTOs;
using MediatR;

namespace GeoMarker.Application.Features.Groups.Queries.GetGroupsByUserId
{
    public record GetGroupsByUserIdQuery
    (
        Guid UserId
    ) : IRequest<GetGroupsByUserIdResponse>;

}
