using GeoMarker.Application.Features.Users.DTOs;
using GeoMarker.Application.Services.IdentityService;
using GeoMarker.Domain.Enums;
using MediatR;

namespace GeoMarker.Application.Features.Users.Commands.CreateUser
{
    public record  CreateUserCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password
    ) : IRequest<CreateUserResponse>;

}
