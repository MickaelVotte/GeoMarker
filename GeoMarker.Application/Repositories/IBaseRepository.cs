using GeoMarker.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> CreateAsync (T entity, CancellationToken cancellationToken = default);
        Task<T> UpdateAsync (T entity, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync (T entity, CancellationToken cancellationToken = default);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
