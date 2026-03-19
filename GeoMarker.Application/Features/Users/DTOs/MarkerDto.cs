using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Users.DTOs
{
    public record MarkerDto
    (
        Guid Id,
        string Title,
        string Description,
        double Latitude,
        double Longitude
    );
}
