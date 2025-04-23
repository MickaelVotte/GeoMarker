using GeoMarker.Domain.Entities;
using GeoMarker.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);

        //User GetUserByEmailAsync(string email);
        //void AddUser(User user);


    }
}