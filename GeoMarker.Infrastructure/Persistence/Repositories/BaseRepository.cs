
using GeoMarker.Domain.Interfaces;
using GeoMarker.Domain.Common;
using GeoMarker.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GeoMarker.Infrastructure.Persistence.Repositories
{
    //public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    //{
    //    private readonly ApplicationDbContext _context;
    //    protected readonly DbSet<T> _dbSet;

    //    protected BaseRepository(ApplicationDbContext context)
    //    {
    //        _context = context;
    //        _dbSet = context.Set<T>();
    //    }

    //    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    //    {
    //        await _dbSet.AddAsync(entity, cancellationToken);
    //        await _context.SaveChangesAsync(cancellationToken);
    //    }

    //    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    //    {
    //       _dbSet.Remove(entity);
    //       await _context.SaveChangesAsync(cancellationToken);
    //    }

    //    public virtual async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    //    {
    //        return await _dbSet.AnyAsync(e => e.Id == id, cancellationToken);
    //    }

    //    public virtual IQueryable<T> GetAllAsync(CancellationToken cancellationToken)
    //    {
    //       return _dbSet.AsNoTracking();
    //    }

    //    public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    //    {
    //        return await _dbSet.FindAsync(id, cancellationToken);
    //    }

    //    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    //    {
    //       _dbSet.Update(entity);
    //        await _context.SaveChangesAsync(cancellationToken);
    //    }

      
    //}
}
