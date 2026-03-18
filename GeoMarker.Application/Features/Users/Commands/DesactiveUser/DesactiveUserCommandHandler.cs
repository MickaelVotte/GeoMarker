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

        public DesactiveUserCommandHandler(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

            return new DesactiveUserResponse(request.Id, user.IsActive);

        }
    }
}
