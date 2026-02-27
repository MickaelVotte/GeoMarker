using GeoMarker.Application.Services.IdentityService;
using GeoMarker.Domain.Entities;
using GeoMarker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Services.IdentityService

{
    public interface IIdentityService
    {
        IdentityResult Register(User user);
        IdentityResult Login(string email, string password);
    }
}
