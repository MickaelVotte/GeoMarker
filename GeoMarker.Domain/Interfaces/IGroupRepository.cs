using GeoMarker.Domain.Entities;


namespace GeoMarker.Domain.Interfaces
{
    public interface IGroupRepository : IBaseRepository<Group>
    {
        Task<IReadOnlyList<Group>> GetGroupsByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        Task AddUserToGroupAsync(Guid groupId, Guid userId, CancellationToken cancellationToken = default);
        Task RemoveUserFromGroupAsync(Guid groupId, Guid userId, CancellationToken cancellationToken = default);
        Task <IReadOnlyList<Group>> GetGroupsByMarkerIdAsync(Guid markerId, CancellationToken cancellationToken = default);

    }
}
