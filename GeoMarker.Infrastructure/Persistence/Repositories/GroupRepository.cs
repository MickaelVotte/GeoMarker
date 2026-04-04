using GeoMarker.Application.Interfaces;
using GeoMarker.Domain.Entities;
using GeoMarker.Infrastructure.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;

namespace GeoMarker.Infrastructure.Persistence.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<IReadOnlyList<Group>> GetGroupsByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(g => g.OwnerId == userId || g.Users.Any(u => u.Id == userId)).ToListAsync(cancellationToken);
        }
        public async Task<IReadOnlyList<Group>> GetGroupsByMarkerIdAsync(Guid markerId, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .Include(g => g.Users)
                .Where(g => g.Users.Any(u => u.Markers.Any(m => m.Id == markerId)))
                .ToListAsync(cancellationToken);
        }
    }
}
