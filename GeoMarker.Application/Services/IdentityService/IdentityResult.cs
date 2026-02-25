using GeoMarker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Services.IdentityService
{
    public record IdentityResult
    (
        User User,
        string Token
    );
    
}
