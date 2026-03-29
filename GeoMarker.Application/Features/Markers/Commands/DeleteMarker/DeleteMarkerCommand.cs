using GeoMarker.Application.Features.Markers.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Markers.Commands.DeleteMarker
{
    public record DeleteMarkerCommand(
        Guid Id,
        Guid UserId
    ) : IRequest<DeleteMarkerResponse>;
}
