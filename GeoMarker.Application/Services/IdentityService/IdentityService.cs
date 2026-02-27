using GeoMarker.Application.Common.Interfaces.Authentification;
using GeoMarker.Application.Common.Interfaces.Persistence;
using GeoMarker.Domain.Entities;

namespace GeoMarker.Application.Services.IdentityService
{
    public class IdentityService : IIdentityService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public IdentityService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public IdentityResult Register(User user)
        {
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new IdentityResult(user, token);

        }

        public IdentityResult Login(string email, string password)
        {
            var user = _userRepository.GetUserByEmailAsync(email).Result;
            if (user == null || user.PasswordHash != password)
            {
                throw new Exception("Invalid credentials");
            }
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new IdentityResult(user, token);
        }
    }
}
