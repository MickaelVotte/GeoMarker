using AutoMapper;
using GeoMarker.Application.Common.Interfaces.Authentification;
using GeoMarker.Application.Common.Interfaces.Persistence;
using GeoMarker.Application.Exceptions;
using GeoMarker.Application.Features.Users.DTOs;
using GeoMarker.Application.Services.IdentityService;
using GeoMarker.Domain.Entities;
using GeoMarker.Domain.Enums;
using MediatR;

namespace GeoMarker.Application.Features.Users.Commands.CreateUser
{
   public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IJwtTokenGenerator jwtTokenGenerator,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
        }
        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userRepository.ExistsByEmailAsync(request.Email, cancellationToken);

            if (userExists)
            {
                throw new EmailAlreadyTakenException(request.Email);
            }

            var passwordHash = _passwordHasher.HashPassword(request.Password);

            var user = new User(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password,
                UserRole.User
                );

            await _userRepository.AddAsync(user, cancellationToken);

            var token = _jwtTokenGenerator.GenerateToken(user);

            return _mapper.Map<CreateUserResponse>(user) with { Token = token};
        }
    }

}
