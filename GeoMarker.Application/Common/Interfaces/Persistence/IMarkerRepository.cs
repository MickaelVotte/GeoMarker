using GeoMarker.Domain.Entities;
using GeoMarker.Domain.Interfaces;


namespace GeoMarker.Application.Interfaces
{
    public interface IMarkerRepository : IBaseRepository<Marker>
    {
        Task<IReadOnlyList<Marker>> GetMarkersByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Marker>> SearchMarkersAsync(string? title, string? description, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Marker>> GetMarkersByLocationAsync(decimal latitude, decimal longitude, decimal radiusInKm, CancellationToken cancellationToken = default);
       
    }
}
