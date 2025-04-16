

using GeoMarker.Domain.Entities;
using GeoMarker.Domain;
using GeoMarker.Infrastructure.Persistence.Context;
using GeoMarker.Domain.Interfaces;
using GeoMarker.Application.Common.Interfaces.Persistence;

namespace GeoMarker.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public void AddUser(User user)
        {
           _users.Add(user);
        }


        public User GetUserByEmailAsync(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);    
        }
    }
}
