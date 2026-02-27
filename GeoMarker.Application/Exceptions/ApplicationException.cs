using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GeoMarker.Application.Exceptions
{
    public class BadRequestException : Exception
    {

        public string[] Errors { get; set; }

        public BadRequestException(string message) : base(message) 
        {
            Errors = new[] { message };
        }

        public BadRequestException(string[] errors) : base("Multiple errors occurred. See error details.")
        {
            Errors = errors ?? throw new ArgumentNullException(nameof(errors));
        }

        public BadRequestException(string message, Exception innerException)
         : base(message, innerException)
        {
            Errors = new[] { message };
        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class ConnectionException : Exception
    {
        public ConnectionException(string message)
            : base(message)
        {
        }

        public ConnectionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class EmailAlreadyTakenException : Exception
    {
        public EmailAlreadyTakenException(string email)
            : base($"User with email '{email}' already exists.")
        {
        }

        public EmailAlreadyTakenException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

