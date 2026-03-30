using AutoMapper;
using GeoMarker.Application.Features.Markers.DTOs;
using GeoMarker.Application.Features.Users.DTOs;
using GeoMarker.Application.Interfaces;
using MediatR;


namespace GeoMarker.Application.Features.Markers.Queries.GetMarkersByUserId
{
    public class GetMarkersByUserIdQueryHandler : IRequestHandler<GetMarkersByUserIdQuery, GetMarkersByUserIdResponse>
    {
        private readonly IMarkerRepository _markerRepository;
        private readonly IMapper _mapper;

        public  GetMarkersByUserIdQueryHandler(IMarkerRepository markerRepository, IMapper mapper)
        {
           _markerRepository = markerRepository;
           _mapper = mapper;
        }

        public async Task<GetMarkersByUserIdResponse> Handle(GetMarkersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var markers = await _markerRepository.GetMarkersByUserIdAsync(request.UserId, cancellationToken);

            var markerDtos = _mapper.Map<IReadOnlyList<MarkerDto>>(markers);
            return new GetMarkersByUserIdResponse(request.UserId, markerDtos);
        }
    }
}
