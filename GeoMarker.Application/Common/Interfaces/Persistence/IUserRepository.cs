using GeoMarker.Domain.Entities;
using GeoMarker.Domain.Interfaces;


namespace GeoMarker.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);

        Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default);

        Task<User?> GetByIdWithMarkersAsync(Guid id, CancellationToken cancellationToken = default);

    }
}