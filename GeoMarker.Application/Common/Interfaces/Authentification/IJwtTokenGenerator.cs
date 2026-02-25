using GeoMarker.Domain.Entities;

namespace GeoMarker.Application.Common.Interfaces.Authentification
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
