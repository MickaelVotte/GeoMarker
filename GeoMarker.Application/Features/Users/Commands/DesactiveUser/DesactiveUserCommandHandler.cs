using AutoMapper;
using GeoMarker.Application.Common.Interfaces.Authentification;
using GeoMarker.Application.Common.Interfaces.Persistence;
using GeoMarker.Application.Features.Users.DTOs;
using MediatR;

namespace GeoMarker.Application.Features.Users.Commands.DesactiveUser
{
    public class DesactiveUserCommandHandler : IRequestHandler<DesactiveUserCommand, DesactiveUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DesactiveUserCommandHandler(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<DesactiveUserResponse> Handle(DesactiveUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {request.Id} not found.");
            }

            if (!user.IsActive)
            {
                throw new InvalidOperationException($"User with ID {request.Id} is already desactivated.");
            }

            user.Desactivate();

            await _userRepository.UpdateAsync(user, cancellationToken);

            return _mapper.Map<DesactiveUserResponse>(user);

        }
    }
}
