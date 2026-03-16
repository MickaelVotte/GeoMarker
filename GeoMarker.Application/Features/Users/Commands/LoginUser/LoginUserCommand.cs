using GeoMarker.Application.Features.Users.DTOs;
using MediatR;


namespace GeoMarker.Application.Features.Users.Commands.LoginUser
{
    public record  LoginUserCommand(
        string Email,
        string Password
    ) : IRequest<LoginUserResponse>;
    
}
