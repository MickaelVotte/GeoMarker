using GeoMarker.Application.Features.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(
        Guid Id,
        string Firstname,
        string Lastname,
        string Email,
        string? Password
    ) : IRequest<UpdateUserResponse>;

}
