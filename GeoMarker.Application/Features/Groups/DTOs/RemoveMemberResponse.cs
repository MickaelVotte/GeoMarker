using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Groups.DTOs
{
    public record RemoveMemberResponse
    (
        Guid UserId,
        string FirstName
     );
    
}
