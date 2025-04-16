using GeoMarker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository 
    {
       User GetUserByEmailAsync(string email);
       void AddUser(User user);

    }
}