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
        void Create (T entity);
        void Update (T entity);
        void Delete (T entity);
        Task<T> Get(Guid Id, CancellationToken cancellationToken);
        Task<List<T>> GetAll(CancellationToken cancellationToken);
    }
}
