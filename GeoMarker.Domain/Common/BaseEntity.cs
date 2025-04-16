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
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTimeOffset CreateAt { get; set; } = DateTime.UtcNow;
        public DateTimeOffset? UpdateAt { get; set; } 
        public DateTimeOffset? DeleteAt { get; set; }
        public bool IsActive { get; set; } = true;
        public UserRole Role { get; set; } = UserRole.User;
    }
}
