using CarJournal.Services.Authentication.Client;

using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace CarJournal.Services.Authentication;

public class ClientAuthenticationService : IClientAuthenticationService
{
    private readonly ProtectedSessionStorage _protectedSessionStorage;

    public ClientAuthenticationService(ProtectedSessionStorage protectedSessionStorage)
    {
        _protectedSessionStorage = protectedSessionStorage;
    }

    public async Task ClearSessionStorage()
    {
        await _protectedSessionStorage.DeleteAsync(SessionStorageConstants.UserSessionStorageKey);
    }

    public async Task UpdateSessionStorage(string jwtToken)
    {
        await _protectedSessionStorage.SetAsync(SessionStorageConstants.UserSessionStorageKey, jwtToken);
    }
}