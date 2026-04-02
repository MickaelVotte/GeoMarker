using AutoMapper;
using GeoMarker.Application.Common.Interfaces.Persistence;
using GeoMarker.Application.Features.Markers.DTOs;
using GeoMarker.Application.Interfaces;
using GeoMarker.Domain.Entities;
using MediatR;



namespace GeoMarker.Application.Features.Markers.Commands.UpdateMarker
{
    public class UpdateMarkerCommandHandler : IRequestHandler<UpdateMarkerCommand, UpdateMarkerResponse>
    {
        private readonly IMarkerRepository _markerRepository;
        private readonly IMapper _mapper;

        public UpdateMarkerCommandHandler(
            IMarkerRepository markerRepository,
            IMapper mapper
            )
        {
            _markerRepository = markerRepository;
            _mapper = mapper;
        }

        public async Task<UpdateMarkerResponse> Handle(UpdateMarkerCommand request, CancellationToken cancellationToken)
        {
            var marker = await _markerRepository.GetByIdAsync(request.Id, cancellationToken);

            if (marker is null)
            {
                throw new KeyNotFoundException($"Marker with id {request.Id} not found.");
            }

            if (marker.UserId != request.UserId)
            {
              throw new UnauthorizedAccessException("You do not have permission to update this marker.");
            }

            marker.UpdateTitle(request.Title);
            marker.UpdateDescription(request.Description);
            marker.UpdateLocation(request.Latitude, request.Longitude);

            await _markerRepository.UpdateAsync(marker, cancellationToken);
            return _mapper.Map<UpdateMarkerResponse>(marker);
        }
    }
}
