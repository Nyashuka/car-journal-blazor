using System.IdentityModel.Tokens.Jwt;

using CarJournal.Services.Authentication.Client;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace CarJournal.Services.Authentication;

public class ClientAuthenticationService : IClientAuthenticationService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ProtectedSessionStorage _protectedSessionStorage;

    public ClientAuthenticationService(ProtectedSessionStorage protectedSessionStorage,
                                       AuthenticationStateProvider authenticationStateProvider)
    {
        _protectedSessionStorage = protectedSessionStorage;
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task ClearSessionStorage()
    {
        await _protectedSessionStorage.DeleteAsync(SessionStorageConstants.UserSessionStorageKey);
        await _protectedSessionStorage.DeleteAsync(SessionStorageConstants.SelectedCar);
    }

    public async Task<string?> GetUserIdAsync()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        return user.Claims.FirstOrDefault(claim => claim.Properties.Any(prop => prop.Value == JwtRegisteredClaimNames.Sub))?.Value;
    }

    public async Task UpdateSessionStorage(string jwtToken)
    {
        await _protectedSessionStorage.SetAsync(SessionStorageConstants.UserSessionStorageKey, jwtToken);
    }
}