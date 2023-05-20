using API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        public string Issuer { get;private set; }
        public string Audience { get; private set; }
        public bool VailidateLifetime { get; private set; }
        public int TokenLifetimeMinutes { get; private set; }

        private readonly string signingKey;
        private readonly SymmetricSecurityKey key;

        public TokenService(string issuer, string audience, string signingKey, bool validateLifetime = true, int tokenLifetimeMinutes = 10) 
        {
            Issuer = issuer;
            Audience = audience;
            VailidateLifetime = validateLifetime;
            TokenLifetimeMinutes = tokenLifetimeMinutes;
            this.signingKey = signingKey;
            this.key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.signingKey));
        }

        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var jwt = new JwtSecurityToken(
                               issuer: Issuer,
                               audience: Audience,
                               claims: claims,
                               expires: DateTime.Now.AddMinutes(TokenLifetimeMinutes),
                               signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(
                                   key,
                                   SecurityAlgorithms.HmacSha256
                                   ));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
