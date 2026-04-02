using GeoMarker.Domain.Common;
using GeoMarker.Domain.Interfaces;


namespace GeoMarker.Domain.Entities
{
    public class Group : BaseEntity, IDesactivable
    {
        public string Name { get; private set; } = null!;
        public string? Description { get; private set; }
        public Guid OwnerId { get; private set; }
        public User Owner { get; private set; } = null!;

        private List<User> _users = new List<User>();
        public virtual IReadOnlyCollection<User> Users => _users.AsReadOnly();

        private Group() { }
        public Group(string name, string? description, Guid ownerId)
        {
            Name = name;
            Description = description;
            OwnerId = ownerId;
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty", nameof(name));
            }
            Name = name;
            UpdateAt = DateTimeOffset.UtcNow;
        }

        public void UpdateDescription(string? description)
        {
            Description = description;
            UpdateAt = DateTimeOffset.UtcNow;
        }

        public void UpdateOwner(Guid ownerId)
        {
            if (ownerId == Guid.Empty)
            {
                throw new ArgumentException("Owner ID cannot be empty", nameof(ownerId));
            }
            OwnerId = ownerId;
            UpdateAt = DateTimeOffset.UtcNow;
        }

        public void AddMember(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            if(OwnerId == user.Id)
            {
                throw new InvalidOperationException("Owner cannot be added as a member");
            }
            if (_users.Contains(user))
            {
                throw new InvalidOperationException("User is already in the group");
            }
            if(_users.Count >= 100)
            {
                throw new InvalidOperationException("Group cannot have more than 100 members");
            }
            _users.Add(user);
            UpdateAt = DateTimeOffset.UtcNow;
        }

        public void RemoveMember(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            if (!_users.Contains(user))
            {
                throw new InvalidOperationException("User is not in the group");
            }
            
            _users.Remove(user);
            UpdateAt = DateTimeOffset.UtcNow;
        }

        public void Desactivate()
        {
            IsActive = false;
            DeleteAt = DateTimeOffset.UtcNow;
        }
    }
}
