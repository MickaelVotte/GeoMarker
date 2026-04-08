using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Users.DTOs
{
    public record DesactiveUserResponse
    {
    public Guid Id { get; init; }
    public bool IsActive { get; init; }
    }

}
