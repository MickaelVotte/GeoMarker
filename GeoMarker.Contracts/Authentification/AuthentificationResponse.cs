using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;



namespace GeoMarker.Contracts.Authentification
{
    public record AuthentificationResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token,
        DateTimeOffset CreateAt,
        DateTimeOffset? UpdateAt,
        DateTimeOffset? DeleteAt,
        Boolean IsActive,
        string Role
        );

}
