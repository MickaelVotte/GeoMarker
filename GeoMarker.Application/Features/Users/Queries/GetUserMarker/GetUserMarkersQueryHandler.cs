using AutoMapper;
using GeoMarker.Application.Common.Interfaces.Persistence;
using GeoMarker.Application.Features.Users.DTOs;
using MediatR;

namespace GeoMarker.Application.Features.Users.Queries.GetUserMarker
{
    public class GetUserMarkersQueryHandler : IRequestHandler<GetUserMarkersQuery, GetUserMarkersResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserMarkersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<GetUserMarkersResponse> Handle(GetUserMarkersQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {request.Id} not found.");
            }
            var markerDtos = _mapper.Map<IReadOnlyList<MarkerDto>>(user.Markers);
            return new GetUserMarkersResponse (user.Id, markerDtos);
        }
    }
}
