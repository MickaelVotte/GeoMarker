using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Contracts.Authentification
{
    public record AuthentificationResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token);

}
