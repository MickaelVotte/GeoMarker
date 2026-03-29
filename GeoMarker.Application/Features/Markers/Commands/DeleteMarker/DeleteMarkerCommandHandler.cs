using GeoMarker.Application.Features.Markers.DTOs;
using MediatR;
using GeoMarker.Application.Common.Interfaces.Persistence;
using GeoMarker.Application.Interfaces;


namespace GeoMarker.Application.Features.Markers.Commands.DeleteMarker
{
    public class DeleteMarkerCommandHandler : IRequestHandler<DeleteMarkerCommand, DeleteMarkerResponse>
    {
        private readonly IMarkerRepository _markerRepository;

        public DeleteMarkerCommandHandler(
            IMarkerRepository markerRepository
            )
        {
            _markerRepository = markerRepository;
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

            return new DeleteMarkerResponse(
                request.Id,
                marker.Title,
                marker.Description ?? string.Empty,
                marker.Latitude,
                marker.Longitude
            );
        }
    }
}
