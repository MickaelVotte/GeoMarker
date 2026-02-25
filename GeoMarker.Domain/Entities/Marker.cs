using GeoMarker.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Domain.Entities
{
    public class Marker : BaseEntity
    {

        public string Title { get; private set; } = null!;
        public string? Description { get; private set; }
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; } = null!;


        private Marker() { }

        public Marker(string title, string? description, decimal latitude, decimal longitude, Guid userId)
        {
            Title = title;
            Description = description;
            Latitude = latitude;
            Longitude = longitude;
            UserId = userId;
        }


    }

}
