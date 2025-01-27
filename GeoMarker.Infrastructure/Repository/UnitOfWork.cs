using GeoMarker.Application.Repository;
using GeoMarker.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
         private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context) 
        {
            _context = context;
        }

        public Task Save(CancellationToken cancellationToken) 
        {
            return _context.SaveChangesAsync();
        }
    }
}
