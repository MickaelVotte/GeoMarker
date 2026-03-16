using GeoMarker.Domain.Common;


namespace GeoMarker.Domain.Entities
{
    public class Marker : BaseEntity
    {

        public string Title { get; private set; } = null!;
        public string? Description { get; private set; }
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }
        public decimal RadiusInKm { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; } = null!;

       


        private Marker() { }

        public Marker(string title, string? description, decimal latitude, decimal longitude, Guid userId)
        {
            validateLocation(latitude, longitude);

            Title = title;
            Description = description;
            Latitude = latitude;
            Longitude = longitude;
            UserId = userId;
        }

        public void UpdateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or empty", nameof(title));
            }
            Title = title;
            UpdateAt = DateTimeOffset.UtcNow;
        }

        public void UpdateDescription(string? description)
        {
            Description = description;
            UpdateAt = DateTimeOffset.UtcNow;
        }

        public void UpdateLocation(decimal latitude, decimal longitude)

        {
            validateLocation(latitude,longitude);

            Latitude = latitude;
            Longitude = longitude;
            UpdateAt = DateTimeOffset.UtcNow;
        }

        public void validateLocation(decimal latitude, decimal longitude)
        {
            if (latitude < -90 || latitude > 90)
            {
                throw new ArgumentOutOfRangeException(nameof(latitude), "Latitude must be between -90 and 90.");
            }
            if (longitude < -180 || longitude > 180)
            {
                throw new ArgumentOutOfRangeException(nameof(longitude), "Longitude must be between -180 and 180.");
            }
        }

    }

}
