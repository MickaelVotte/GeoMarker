using GeoMarker.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Domain.Entities
{
    public class User : BaseEntity
    {

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }


        public User(string firstname, string lastname, string email, string passwordHash)
        {

            FirstName = firstname;
            LastName = lastname;
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}
