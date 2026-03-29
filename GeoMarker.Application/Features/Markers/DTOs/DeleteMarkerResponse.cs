using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Markers.DTOs
{
    public record DeleteMarkerResponse
    (
        Guid Id,
        string Title,
        string Description,
        decimal Latitude,
        decimal Longitude
    );
}
