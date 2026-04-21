using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Markers.DTOs
{
    public record DeleteMarkerResponse
    {
        public Guid Id { get; init; }
        public string Title { get; init; } = null!;
        public string Description { get; init; } = null!;
        public decimal Latitude { get; init; }
        public decimal Longitude { get; init; } 
        public bool IsActive { get; init; } 
    }
        
    
}
