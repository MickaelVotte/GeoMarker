using GeoMarker.Domain.Entities;
using GeoMarker.Domain.Interfaces;


namespace GeoMarker.Application.Interfaces
{
    public interface IGroupRepository : IBaseRepository<Group>
    {
        Task<IReadOnlyList<Group>> GetGroupsByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        Task <IReadOnlyList<Group>> GetGroupsByMarkerIdAsync(Guid markerId, CancellationToken cancellationToken = default);

    }
}
