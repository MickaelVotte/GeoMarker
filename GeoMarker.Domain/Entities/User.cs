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


        public void EmailUpdate(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or empty", nameof(email));
            }
            if(email.Length > 255)
            {
                throw new ArgumentException("Email cannot be longer than 255 characters", nameof(email));
            }
            if(!email.Contains("@"))
            {
                throw new ArgumentException("Email must contain @ character", nameof(email));
            }
            Email = email;
            UpdateAt = DateTimeOffset.UtcNow;
        }

        public void PasswordUpdate(string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                throw new ArgumentException("Password hash cannot be null or empty", nameof(passwordHash));
            }
            PasswordHash = passwordHash;
            UpdateAt = DateTimeOffset.UtcNow;
        }

        public void RoleUpdate(UserRole role)
        {
            if (Enum.IsDefined(typeof(UserRole), role))
            {
                Role = role;
                UpdateAt = DateTimeOffset.UtcNow;
            }
            else
            {
                throw new ArgumentException("Invalid user role", nameof(role));
            }
        }

        public void NameUpdate(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name cannot be null or empty", nameof(firstName));
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name cannot be null or empty", nameof(lastName));
            }
            FirstName = firstName;
            LastName = lastName;
            UpdateAt = DateTimeOffset.UtcNow;
        }

        public void AddMarker(Marker marker)
        {
            if (marker == null)
            {
                throw new ArgumentNullException(nameof(marker), "Marker cannot be null");
            }
            if (marker.UserId != Id)
            {
                throw new ArgumentException("Marker's UserId does not match the user's Id", nameof(marker));
            }
            if(_markers.Any(m => m.Id == marker.Id))
            {
                throw new ArgumentException("Marker with the same Id already exists for this user", nameof(marker));
            }
            _markers.Add(marker);
            UpdateAt = DateTimeOffset.UtcNow;
        }

        public void RemoveMarker(Marker marker)
        {
            if (marker == null)
            {
                throw new ArgumentNullException(nameof(marker), "Marker cannot be null");
            }
            _markers.Remove(marker);
            UpdateAt = DateTimeOffset.UtcNow;
        }

        public void ClearMarkers()
        {
            _markers.Clear();
            UpdateAt = DateTimeOffset.UtcNow;
        }

        public void Desactivate()
        {
            IsActive = false;
            UpdateAt = DateTimeOffset.UtcNow;
        }   

    }
}
