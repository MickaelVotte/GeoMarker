using GeoMarker.Application.Features.Users.DTOs;
using MediatR;

namespace GeoMarker.Application.Features.Users.Commands.CreateUser
{
    public record  CreateUserCommand(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Password
    ) : IRequest<CreateUserResponse>;

}
