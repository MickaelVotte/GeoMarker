using GeoMarker.Application.Features.Users.DTOs;
using MediatR;

namespace GeoMarker.Application.Features.Users.Queries.GetUserMarker
{
    public record GetUserMarkersQuery(
        Guid UserId
        ) : IRequest<GetUserMarkersResponse>;
}
