using System.Security.Claims;

namespace GuestHibajelentesEvvegi.Services
{
    public interface IAuthService
    {
        (string accessToken, string refreshToken) GenerateTokens(string userId, string username, IEnumerable<string> roles);
        bool ValidateRefreshToken(string refreshToken);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
