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
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTimeOffset CreateAt { get; private set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? UpdateAt { get; protected set; } 
        public DateTimeOffset? DeleteAt { get; private set; }
        public bool IsActive { get; private set; } = true;
    }
}
