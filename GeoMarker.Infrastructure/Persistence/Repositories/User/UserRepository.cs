
using GeoMarker.Application.Repositories.UserRepository;
using GeoMarker.Domain.Entities;
using GeoMarker.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Infrastructure.Persistence.Repositories.UserRepository
{
    public class UserRepository : BaseRepository<User>,IUserRepository
    {
       
        public UserRepository(ApplicationDbContext context) : base(context)
        {           
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return true;
        }
    }
}
