using GeoMarker.Application.Features.Markers.DTOs;
using MediatR;

namespace GeoMarker.Application.Features.Markers.Queries.GetMarkersByUserId
{
    public record GetMarkersByUserIdQuery
    (
        Guid UserId

    ): IRequest<GetMarkersByUserIdResponse>;   

}
