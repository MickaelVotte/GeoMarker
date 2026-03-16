
namespace GeoMarker.Application.Features.Users.DTOs
{
    public record LoginUserResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token
    );
  
}
