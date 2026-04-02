using GeoMarker.Application.Features.Markers.DTOs;
using MediatR;
using GeoMarker.Application.Interfaces;
using AutoMapper;


namespace GeoMarker.Application.Features.Markers.Commands.DeleteMarker
{
    public class DeleteMarkerCommandHandler : IRequestHandler<DeleteMarkerCommand, DeleteMarkerResponse>
    {
        private readonly IMarkerRepository _markerRepository;
        private readonly IMapper _mapper;   

        public DeleteMarkerCommandHandler(
            IMarkerRepository markerRepository,
            IMapper mapper

            )
        {
            _markerRepository = markerRepository;
            _mapper = mapper;
        }   

        public async Task<DeleteMarkerResponse> Handle(DeleteMarkerCommand request, CancellationToken cancellationToken)
        {
            var marker = await _markerRepository.GetByIdAsync(request.Id, cancellationToken);
            if (marker is null)
            {
                throw new KeyNotFoundException($"Marker with id {request.Id} not found.");
            }
            if (marker.UserId != request.UserId)
            {
                throw new UnauthorizedAccessException("You do not have permission to delete this marker.");
            }
            marker.DesactivateMarker();
            
            await _markerRepository.UpdateAsync(marker, cancellationToken);

            return _mapper.Map<DeleteMarkerResponse>(marker);
        }
    }
}
