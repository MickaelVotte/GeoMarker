using GeoMarker.Application.Features.Groups.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Groups.Commands.DeleteGroup
{
    public record DeleteGroupCommand
    (
        Guid OwnerId,
        Guid GroupId
    ) : IRequest<DeleteGroupResponse>;
}
