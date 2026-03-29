using GeoMarker.Application.Features.Markers.DTOs;
using MediatR;

namespace GeoMarker.Application.Features.Markers.Commands.UpdateMarker
{
    public record UpdateMarkerCommand
    (
        Guid Id,
        string Title,
        string? Description,
        decimal Latitude,
        decimal Longitude,
        Guid UserId
    ) : IRequest<UpdateMarkerResponse>;
}
