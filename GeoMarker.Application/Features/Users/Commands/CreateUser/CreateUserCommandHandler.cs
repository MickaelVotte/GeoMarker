using GeoMarker.Application.Common.Interfaces.Authentification;
using GeoMarker.Application.Common.Interfaces.Persistence;
using GeoMarker.Application.Common.Interfaces.Services;
using GeoMarker.Application.Services.IdentityService;
using GeoMarker.Domain.Entities;
using MediatR;

namespace GeoMarker.Application.Features.Users.Commands.CreateUser
{
   public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IdentityResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<IdentityResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userRepository.ExistsByEmailAsync(request.Email, cancellationToken);

            if (userExists)
            {
                throw new Exception("User with this email already exists.");
            }

            var passwordHash = _passwordHasher.HashPassword(request.Password);

            var user = new User(
                request.FirstName,
                request.LastName,
                request.Email,
                passwordHash
             );

            await _userRepository.AddAsync(user, cancellationToken);

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new IdentityResult(user, token);
        }
    }

}
