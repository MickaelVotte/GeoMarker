using AutoMapper;
using GeoMarker.Application.Features.Markers.DTOs;
using GeoMarker.Application.Features.Users.DTOs;
using GeoMarker.Application.Interfaces;
using MediatR;

namespace GeoMarker.Application.Features.Markers.Queries.SearchMarkers
{
    public class SearchMarkersQueryHandler : IRequestHandler<SearchMarkersQuery, SearchMarkersResponse>
    {
        private readonly IMarkerRepository _markerRepository;
        private readonly IMapper _mapper;
        public SearchMarkersQueryHandler(IMarkerRepository markerRepository, IMapper mapper)
        {
            _markerRepository = markerRepository;
            _mapper = mapper;
        }

        public async Task<SearchMarkersResponse> Handle(SearchMarkersQuery request, CancellationToken cancellationToken)
        {
            var markers = await _markerRepository.SearchMarkersAsync(request.Title, request.Description, cancellationToken);
            var markerDtos = _mapper.Map<IReadOnlyList<MarkerDto>>(markers);
            return new SearchMarkersResponse(markerDtos);
        }
    }
}
