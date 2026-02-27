using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Common.Interfaces.Utility
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
