using GeoMarker.Application.Features.Users.DTOs;
using GeoMarker.Domain.Entities;
using MediatR;

namespace GeoMarker.Application.Features.Users.Queries.GetUserMarker
{
    public record GetUserMarkersQuery(
        Guid UserId
        ) : IRequest<GetUserMarkersResponse>;
}
