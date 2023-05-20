using API.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
    public interface ITokenService
    {
        string GenerateToken(IEnumerable<Claim> claims);
    }
}
