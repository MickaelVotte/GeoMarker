using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Infrastructure.Services
{
    public class JwtSettings
    {
        public const string SectionName = "JwtSettings";
        public string Secret { get; init; } = null!;
        public int ExpirationInMinutes { get; init; } = 60;
        public string Issuer { get; init; } = null!;
        public string Audience { get; init; } = null!;
       
    }

   
}
