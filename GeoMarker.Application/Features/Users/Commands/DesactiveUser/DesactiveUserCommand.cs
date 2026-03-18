using GeoMarker.Application.Features.Users.DTOs;
using MediatR;
using System;

namespace GeoMarker.Application.Features.Users.Commands.DesactiveUser
{
    public record DesactiveUserCommand(Guid Id) : IRequest<DesactiveUserResponse>;

}
