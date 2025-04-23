using GeoMarker.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Add (T entity, CancellationToken cancellationToken = default);
        void Update (T entity, CancellationToken cancellationToken = default);
        List<T> GetAll(CancellationToken cancellationToken);
        void Delete (T entity, CancellationToken cancellationToken = default);
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
