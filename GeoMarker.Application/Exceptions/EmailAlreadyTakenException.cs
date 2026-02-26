using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Exceptions
{
    public class EmailAlreadyTakenException : Exception
    {
        public EmailAlreadyTakenException(string email) : base($"The email '{email}' is already taken.")
        {
        }
    }
}
