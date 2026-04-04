

using GeoMarker.Domain.Entities;
using GeoMarker.Infrastructure.Persistence.DataContext;
using GeoMarker.Application.Common.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GeoMarker.Infrastructure.Persistence.Repositories 
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) :base(context)
        {
        }
        public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AnyAsync(u => u.Email == email, cancellationToken);
        }

        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Email == email, cancellationToken);
        } 
    }
}
