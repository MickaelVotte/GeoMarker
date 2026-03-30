using GeoMarker.Application.Features.Markers.DTOs;
using MediatR;

namespace GeoMarker.Application.Features.Markers.Queries.GetMarkersByLocation
{
    public record GetMarkersByLocationQuery
    (
        decimal Latitude,
        decimal Longitude,
        decimal RadiusInKm
    ) : IRequest<GetMarkersByLocationResponse>;

}
