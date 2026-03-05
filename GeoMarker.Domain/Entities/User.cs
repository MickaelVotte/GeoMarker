using GeoMarker.Domain.Common;
using GeoMarker.Domain.Enums;

namespace GeoMarker.Domain.Entities
{
    public class User : BaseEntity
    {

        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string PasswordHash { get; private set; } = null!;
        public UserRole Role { get; private set; } = UserRole.User;

        private List<Marker> _markers = new List<Marker>();
        //We use virtual to allow EF Core to create "proxies" and load markers only when we need them
        public virtual IReadOnlyCollection<Marker> Markers => _markers.AsReadOnly();


        private User() { }

        public User(string firstname, string lastname, string email, string passewordhash, UserRole role)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            PasswordHash = passewordhash;
            Role = role;
        }
    }

}
