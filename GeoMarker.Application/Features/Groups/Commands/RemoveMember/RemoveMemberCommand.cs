using GeoMarker.Application.Features.Groups.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Groups.Commands.RemoveMember
{
    public record RemoveMemberCommand
    (
        Guid GroupeId,
        Guid OwnerId,
        Guid MemberId
    ) : IRequest<RemoveMemberResponse>;

}
