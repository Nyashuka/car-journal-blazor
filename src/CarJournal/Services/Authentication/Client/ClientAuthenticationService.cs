using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using CarJournal.Infrastructure.Authentication;
using CarJournal.Services.Authentication.Client;

using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.IdentityModel.Tokens;

namespace CarJournal.Services.Authentication;

public class ClientAuthenticationService : IClientAuthenticationService
{
    private readonly ProtectedSessionStorage _protectedSessionStorage;

    public ClientAuthenticationService(ProtectedSessionStorage protectedSessionStorage)
    {
        _protectedSessionStorage = protectedSessionStorage;
    }

    public async Task UpdateSessionStorage(string jwtToken)
    {
        await _protectedSessionStorage.SetAsync(SessionStorageConstants.UserSessionStorageKey, jwtToken);
    }
}