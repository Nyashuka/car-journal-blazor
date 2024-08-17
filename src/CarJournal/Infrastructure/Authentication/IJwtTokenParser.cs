using System.Security.Claims;

namespace CarJournal.Infrastructure.Authentication;

public interface IJwtTokenParser
{
    ClaimsPrincipal ValidateTokenOrGetNull(string token);

}