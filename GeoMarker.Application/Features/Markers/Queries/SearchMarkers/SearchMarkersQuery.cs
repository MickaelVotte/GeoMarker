using GeoMarker.Application.Features.Markers.DTOs;
using MediatR;

namespace GeoMarker.Application.Features.Markers.Queries.SearchMarkers
{
    public record SearchMarkersQuery
    (
        string? Title,
        string? Description
    ) : IRequest<SearchMarkersResponse>;
}
