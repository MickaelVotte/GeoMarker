using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Users.DTOs
{
    public record UpdateUserResponse
    {
        public Guid Id { get; init; }
        public string Firstname { get; init; } = null!;
        public string Lastname { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string Token { get; init; } = null!;
    }

}
