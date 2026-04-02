using GeoMarker.Domain.Common;

namespace GeoMarker.Domain.Interfaces
{
    public interface IBaseRepository<T>  where T : BaseEntity, IDesactivable
    {
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
        Task <IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
       
    }
}
