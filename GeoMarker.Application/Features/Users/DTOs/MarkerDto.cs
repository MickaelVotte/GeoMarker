using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Users.DTOs
{
    public record MarkerDto
    {        
        public Guid Id { get; init; }
        public string Title { get; init; } = null!;
        public string Description { get; init; } = null!;
        public double Latitude { get; init; }
        public double Longitude { get; init; }
        public bool IsActive { get; init; }
    }
}
