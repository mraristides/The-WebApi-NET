using System.Collections.Generic;
using System.Security.Claims;

namespace Sample.Application.Services
{
    public interface ITokenAppService
    {
         string GenerateAccessToken(IEnumerable<Claim> claims);

         string GenerateRefreshToken();

         ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}