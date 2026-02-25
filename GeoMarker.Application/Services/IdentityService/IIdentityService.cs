using GeoMarker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Services.Authentification
{
    public interface IIdentityService
    {
        Task<IdentityResult> Login(string email, string password);

        Task<IdentityResult> Register(string firstName, string lastName, string email, string password);
    }
}
