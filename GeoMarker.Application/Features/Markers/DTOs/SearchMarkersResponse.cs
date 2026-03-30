using GeoMarker.Application.Features.Users.DTOs;

namespace GeoMarker.Application.Features.Markers.DTOs
{
    public record SearchMarkersResponse
    (
        IReadOnlyList<MarkerDto> Markers
    );
}
