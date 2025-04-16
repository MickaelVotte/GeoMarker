using GeoMarker.Application.Common.Interfaces.Authentification;
using GeoMarker.Application.Common.Interfaces.Persistence;
using GeoMarker.Domain.Entities;
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
        private readonly IUserRepository _userRepository;

        public AuthentificationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;   
        }

        public AuthentificationResult Register(string firstName, string lastName, string email, string password)
        {

            //check if the user exists in the database
            //if not, throw an exception
            if (_userRepository.GetUserByEmailAsync(email) != null)
            {
                //if the user exists, throw an exception
                throw new Exception("User with given email already exists");
            }   
            //create a new user if the user does not exist
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
            };

            _userRepository.AddUser(user);

 
            Guid userId = Guid.NewGuid();

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthentificationResult(
                user,
                token
            );
        }

        public AuthentificationResult Login(string email, string password)
        {

            //check if the user exists in the database
            
            if (_userRepository.GetUserByEmailAsync(email) is not User user)
            {
                //if the user does not exist, throw an exception
                throw new Exception("User with given email does not exist");
            }
            
            if(user.Password != password)
            {
                //if the password is incorrect, throw an exception
                throw new Exception("Password is incorrect");
            }
            
            var token = _jwtTokenGenerator.GenerateToken(user);

            //create jwt token

            return new AuthentificationResult(
                user,
                token
            );
        }
      
    }
}
