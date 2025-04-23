
using GeoMarker.Domain.Interfaces;
using GeoMarker.Domain.Common;
using GeoMarker.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        protected BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Add(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity, CancellationToken cancellationToken = default)
        {
           _dbSet.Remove(entity);
           _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AnyAsync(e => e.Id == id, cancellationToken);
        }

        public List<T> GetAll(CancellationToken cancellationToken)
        {
           return _dbSet.ToList();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        public void Update(T entity, CancellationToken cancellationToken = default)
        {
           _dbSet.Update(entity);
        }
    }
}
