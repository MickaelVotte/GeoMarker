

using GeoMarker.Domain.Entities;
using GeoMarker.Domain;
using GeoMarker.Infrastructure.Persistence.Context;
using GeoMarker.Domain.Interfaces;
using GeoMarker.Application.Common.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GeoMarker.Infrastructure.Persistence.Repositories
{
    public sealed class UserRepository : BaseRepository<User>,IUserRepository
    {
        //private readonly List<User> _users = new();

        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().SingleOrDefaultAsync(u => u.Email == email);

        }
    

        //public User GetUserByEmailAsync(string email)
        //{
        //    return _users.SingleOrDefault(u => u.Email == email);    
        //}

    }
}
