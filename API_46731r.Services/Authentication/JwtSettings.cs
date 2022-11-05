using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Services.Authentication
{
    public class JwtSettings
    {
        public const string Jwt = "Jwt";

        public string Issuer { get; init; } = null!;
        public string Audience { get; init; } = null!;
        public string Secret { get; init; } = null!;
        public int ExpirationTimeInMinutes { get; init; }
    }
}
