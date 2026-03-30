using AutoMapper;
using GeoMarker.Application.Features.Markers.DTOs;
using GeoMarker.Application.Features.Users.DTOs;
using GeoMarker.Application.Interfaces;
using MediatR;

namespace GeoMarker.Application.Features.Markers.Queries.GetMarkersByLocation
{
    public class GetMarkersByLocationQueryHandler : IRequestHandler<GetMarkersByLocationQuery, GetMarkersByLocationResponse>
    {
        private readonly IMarkerRepository _markerRepository;
        private readonly IMapper _mapper;
        public GetMarkersByLocationQueryHandler(IMarkerRepository markerRepository, IMapper mapper)
        {
            _markerRepository = markerRepository;
            _mapper = mapper;
        }

        public async Task<GetMarkersByLocationResponse> Handle(GetMarkersByLocationQuery request, CancellationToken cancellationToken)
        {
            var markers = await _markerRepository.GetMarkersByLocationAsync(request.Latitude, request.Longitude, request.RadiusInKm, cancellationToken);
            var markerDtos = _mapper.Map<IReadOnlyList<MarkerDto>>(markers);
            return new GetMarkersByLocationResponse(markerDtos);
        }
    }
}