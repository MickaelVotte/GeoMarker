

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
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().SingleOrDefaultAsync(u => u.Email == email);

        }
  
    }
}
