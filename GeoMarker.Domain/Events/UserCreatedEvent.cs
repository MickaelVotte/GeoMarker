using GeoMarker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Domain.Events
{
    public class UserCreatedEvent
    {
        public User User { get; }
        public DateTime OccuredOn {get; }

        public UserCreatedEvent(User user) 
        {
            User = user;
            OccuredOn = DateTime.UtcNow;
        }
    }
}
