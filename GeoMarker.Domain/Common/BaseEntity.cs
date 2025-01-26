using GeoMarker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; protected set; }
        public DateTime CreateAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; private set; } = DateTime.UtcNow;
        public bool IsActive { get; private set; } = true;
        public UserRole Role { get; private set; } = UserRole.User;
    }
}
