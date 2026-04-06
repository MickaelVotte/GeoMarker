
namespace GeoMarker.Application.Features.Users.DTOs
{
    public record LoginUserResponse
    {
        public string Email { get; init; } = null!;
        public string Token { get; init; } = null!;
    }
  
}
