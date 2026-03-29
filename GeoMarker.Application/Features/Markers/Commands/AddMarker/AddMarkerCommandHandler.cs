

using AutoMapper;
using GeoMarker.Application.Common.Interfaces.Authentification;
using GeoMarker.Application.Common.Interfaces.Persistence;
using GeoMarker.Application.Features.Markers.DTOs;
using GeoMarker.Application.Interfaces;
using GeoMarker.Domain.Entities;
using MediatR;

namespace GeoMarker.Application.Features.Markers.Commands.AddMarker
{
    public class AddMarkerCommandHandler : IRequestHandler<AddMarkerCommand, AddMarkerResponse>
    {
        private readonly IMarkerRepository _markerRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public AddMarkerCommandHandler(
            IMarkerRepository markerRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _markerRepository = markerRepository;
            _mapper = mapper;
        }

        public async Task<AddMarkerResponse> Handle(AddMarkerCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

            if (user == null)
            {
                throw new Exception($"User with ID {request.UserId} does not exist.");
            }


            var marker = new Marker(
                title: request.Title,
                description: request.Description,
                latitude: request.Latitude,
                longitude: request.Longitude,
                userId: request.UserId
            );

            user.AddMarker(marker);

            await _userRepository.UpdateAsync(user, cancellationToken);

            return _mapper.Map<AddMarkerResponse>(marker);
        }
    }
}
