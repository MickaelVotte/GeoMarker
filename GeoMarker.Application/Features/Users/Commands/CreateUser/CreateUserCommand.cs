using GeoMarker.Application.Services.IdentityService;
using MediatR;

namespace GeoMarker.Application.Features.Users.Commands.CreateUser
{
    public record  CreateUserCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password
    ) : IRequest<IdentityResult>;

}
