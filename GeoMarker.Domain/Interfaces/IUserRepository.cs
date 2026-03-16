using GeoMarker.Domain.Entities;


namespace GeoMarker.Domain.Interfaces
{ 
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);

        Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default);

    }
}