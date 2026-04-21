using GeoMarker.Application.Interfaces;
using GeoMarker.Domain.Entities;
using GeoMarker.Infrastructure.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GeoMarker.Infrastructure.Persistence.Repositories
{
    public class MarkerRepository : BaseRepository<Marker>, IMarkerRepository
    {
        public MarkerRepository(ApplicationDbContext context) : base(context)
        {
           
        }

        public async Task<IReadOnlyList<Marker>> GetMarkersByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(m => m.UserId == userId).ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<Marker>> SearchMarkersAsync(string? title, string? description, CancellationToken cancellationToken = default)
        {
            var query = _dbSet.AsQueryable();
            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(m => m.Title.Contains(title));
            }
            if (!string.IsNullOrEmpty(description))
            {
                query = query.Where(m => m.Description.Contains(description));
            }
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<Marker>> GetMarkersByLocationAsync(decimal latitude, decimal longitude, decimal radiusInKm, CancellationToken cancellationToken = default)
        {
            var radiusInDegrees = radiusInKm / 111.32m; // Approximate conversion from km to degrees
            var minLatitude = latitude - radiusInDegrees;
            var maxLatitude = latitude + radiusInDegrees;
            var minLongitude = longitude - radiusInDegrees;
            var maxLongitude = longitude + radiusInDegrees;
            return await _dbSet.Where(m => m.Latitude >= minLatitude && m.Latitude <= maxLatitude &&
                                            m.Longitude >= minLongitude && m.Longitude <= maxLongitude)
                               .ToListAsync(cancellationToken);
        }   

        public async Task<Marker?> GetMarkerByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
        }
    }
}
