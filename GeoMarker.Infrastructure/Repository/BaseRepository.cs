using GeoMarker.Domain.Common;
using GeoMarker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Infrastructure.Repository
{
    public class BaseRepository<T> where T : BaseEntity
    {
        protected readonly  ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add(entity);
        }

        public void Update(T entity) 
        {
            _context.Update(entity);
        }

        public void Delete(T entity) 
        {
           entity.CreateAt = DateTimeOffset.Now; 
            _context.Update(entity);
        }

        public Task<T> Get(Guid id, CancellationToken cancellationToken) 
        {
            return _context.Set<T>().FirstOrDefaultAsync(x=>x.Id == id, cancellationToken);
        }

        public Task<List<T>> GetAll(CancellationToken cancellationToken) 
        {
            return _context.Set<T>().ToListAsync(cancellationToken);
        }
    }
}
