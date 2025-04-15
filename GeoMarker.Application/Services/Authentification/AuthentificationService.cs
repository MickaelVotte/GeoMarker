using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Services.Authentification
{
    public class AuthentificationService : IAuthentificationService
    {
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

        public AuthentificationResult Register(string firstName, string lastName, string email, string password)
        {
            return new AuthentificationResult(
                Guid.NewGuid(),
                firstName,
                lastName,
                email,
                "token"
                );
        }
    }
}
