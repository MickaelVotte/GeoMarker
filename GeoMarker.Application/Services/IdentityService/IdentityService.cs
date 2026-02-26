using GeoMarker.Application.Common.Interfaces.Authentification;
using GeoMarker.Application.Common.Interfaces.Persistence;
using GeoMarker.Application.Services.IdentityService;
using GeoMarker.Domain.Entities;
using GeoMarker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

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
    }
}
