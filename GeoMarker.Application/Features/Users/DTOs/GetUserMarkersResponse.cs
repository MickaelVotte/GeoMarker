using GeoMarker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Users.DTOs
{
    public record GetUserMarkersResponse
    (
        Guid UserId,
        IReadOnlyList<MarkerDto> Markers
    );
    
 
}
