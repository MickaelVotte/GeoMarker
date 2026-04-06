
namespace GeoMarker.Application.Features.Users.DTOs
{
    public record CreateUserResponse
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string Token { get; init; } = null!;
    }
}
