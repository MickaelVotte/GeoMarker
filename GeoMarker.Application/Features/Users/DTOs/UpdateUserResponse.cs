using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Users.DTOs
{
    public record UpdateUserResponse(
        Guid Id,
        string Firstname,
        string Lastname,
        string Email,
        string Token
    );

}
