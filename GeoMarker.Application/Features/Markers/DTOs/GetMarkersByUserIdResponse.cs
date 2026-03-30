using GeoMarker.Application.Features.Users.DTOs;

namespace GeoMarker.Application.Features.Markers.DTOs
{
    public record GetMarkersByUserIdResponse
    (
        Guid UserId,
        IReadOnlyList<MarkerDto> Markers
    );
}
