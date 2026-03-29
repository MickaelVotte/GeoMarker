using GeoMarker.Application.Features.Markers.DTOs;
using MediatR;


namespace GeoMarker.Application.Features.Markers.Commands.AddMarker
{
    public record AddMarkerCommand(
        string Title,
        string? Description,
        decimal Latitude,
        decimal Longitude,
        Guid UserId
        ): IRequest<AddMarkerResponse>;
}
