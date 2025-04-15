using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Services.Authentification
{
    public interface IAuthentificationService
    {
        AuthentificationResult Login(string username, string password);

        AuthentificationResult Register(string firstName, string lastName, string email, string password);
    }
}
