

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

        public void Add(User user, CancellationToken cancellationToken = default)
        {
            _users.Add(user);
        }

        public void Delete(User user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public void Update(User user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
           return _users.SingleOrDefault(u => u.Email == email);
        }
    

        //public User GetUserByEmailAsync(string email)
        //{
        //    return _users.SingleOrDefault(u => u.Email == email);    
        //}

    }
}
