using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AspnetCore2.Jwt.Api.JwtBearer
{
    public class TokenOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecurityKey { get; set; }
        public string GenerateJti() => Guid.NewGuid().ToString("N");

        public SymmetricSecurityKey Key { get; private set; }
        public SigningCredentials Credentials { get; private set; }

        public TokenOptions(string securityKey, string issuer, string audience)
        {
            (SecurityKey, Issuer, Audience) = (securityKey, issuer, audience);
            
            this.Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.SecurityKey));
            this.Credentials = new SigningCredentials(this.Key, SecurityAlgorithms.HmacSha256);
        }
    }
}