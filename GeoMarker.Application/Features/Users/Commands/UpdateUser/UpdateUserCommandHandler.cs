using AutoMapper;
using GeoMarker.Application.Common.Interfaces.Authentification;
using GeoMarker.Application.Common.Interfaces.Persistence;
using GeoMarker.Application.Exceptions;
using GeoMarker.Application.Features.Users.DTOs;
using MediatR;

namespace GeoMarker.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
  
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(
            IMapper mapper,
            IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator,
            IPasswordHasher passwordHasher
           )

        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordHasher = passwordHasher;
            _mapper = mapper;

        }
        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user is null)
            {
                throw new Exception("User not found");
            }
            else
            {
                user.NameUpdate(request.Firstname, request.Lastname);
            }
                
            var emailExists = await _userRepository.ExistsByEmailAsync(request.Email, cancellationToken);
            if (emailExists && user.Email != request.Email)
            {
                throw new EmailAlreadyTakenException(request.Email);
            }
            else 
            {
                user.EmailUpdate(request.Email);
            }   

            if (!string.IsNullOrEmpty(request.Password))
            {
                var passwordHash = _passwordHasher.HashPassword(request.Password);
                if (passwordHash == null)
                {
                    throw new Exception("Password hashing failed");
                }
                else
                {
                    user.PasswordUpdate(passwordHash);
                }
            }

               
            await _userRepository.UpdateAsync(user, cancellationToken);
            var token = _jwtTokenGenerator.GenerateToken(user);
            return _mapper.Map<UpdateUserResponse>(user) with { Token = token };

        }
    }
}
