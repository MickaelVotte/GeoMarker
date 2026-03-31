using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Groups.DTOs
{
    public record AddMemberResponse
    (
        Guid UserId,
        string FirstName,
        Guid GroupId
    );

}
