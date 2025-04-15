using GeoMarker.Application.Common.Interfaces.Authentification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Services.Authentification
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthentificationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthentificationResult Register(string firstName, string lastName, string email, string password)
        {

            //check if the user exists in the database
            //if not, throw an exception
            //create a new user if the user does not exist
            //if the user exists, check if the password is correct
            //if not, throw an exception
            //if the password is correct, create a new token and return it

            Guid userId = Guid.NewGuid();

            var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName, email);

            return new AuthentificationResult(
                userId,
                firstName,
                lastName,
                email,
                token
                );
        }

        public AuthentificationResult Login(string email, string password)
        {
          
            return new AuthentificationResult(
                Guid.NewGuid(),
                "firstName",
                "lastName",
                email,
                "token"
                );
        }
      
    }
}
