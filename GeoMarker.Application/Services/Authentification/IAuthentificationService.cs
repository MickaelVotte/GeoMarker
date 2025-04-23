using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Services.Authentification
{
    public interface IAuthentificationService
    {
        Task<AuthentificationResult> Login(string email, string password);

        Task <AuthentificationResult> Register(string firstName, string lastName, string email, string password);
    }
}
