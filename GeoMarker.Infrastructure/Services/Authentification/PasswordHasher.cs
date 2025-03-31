using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoMarker.Application.Interfaces;

namespace GeoMarker.Infrastructure.Services.Authentification
{
    class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return password;
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            return true;
        }
    }
}
