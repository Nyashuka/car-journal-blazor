using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Microsoft.IdentityModel.Tokens;

namespace CarJournal.Infrastructure.Authentication;

public class JwtTokenParser : IJwtTokenParser
{
    public ClaimsPrincipal ValidateTokenOrGetNull(string token)
    {
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                    JwtTokenConstants.JwtKey
        ));

        // Налаштування параметрів перевірки токена
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            ClaimsPrincipal principal = tokenHandler.ValidateToken(
                token, tokenValidationParameters, out SecurityToken validatedToken);

            return principal;
        }
        catch (SecurityTokenException)
        {
            return null;
        }
    }


}