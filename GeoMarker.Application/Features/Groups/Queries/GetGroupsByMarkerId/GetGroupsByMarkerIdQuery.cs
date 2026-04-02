using GeoMarker.Application.Features.Groups.DTOs;
using MediatR;

namespace GeoMarker.Application.Features.Groups.Queries.GetGroupsByMarkerId
{
    public record GetGroupsByMarkerIdQuery
    (
        Guid MarkerId
    ) : IRequest<GetGroupsByMarkerIdResponse>;
    
}
