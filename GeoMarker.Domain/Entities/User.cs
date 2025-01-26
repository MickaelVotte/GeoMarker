using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Domain.Entities
{
    public class User
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string email { get; private set; }
        public string passwordHash { get; private set; }
    }
}
