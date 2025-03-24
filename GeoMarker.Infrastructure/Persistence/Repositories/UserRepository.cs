

using GeoMarker.Domain.Entities;
using GeoMarker.Domain.;
using GeoMarker.Infrastructure.Persistence.Context;
using GeoMarker.Application.Interfaces;

namespace GeoMarker.Infrastructure.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<bool> EmailExistsAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
