
using System.Security.Claims;

using CarJournal.Infrastructure.Authentication;
using CarJournal.Services.Authentication.Client;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace CarJournal.Services.Authentication;

public class CarJournalAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ProtectedSessionStorage _protectedSessionStorage;
    private readonly IJwtTokenParser _jwtTokenParser;
    private readonly ClaimsPrincipal _anonymousPrincipals = new ClaimsPrincipal(new ClaimsIdentity());

    public CarJournalAuthenticationStateProvider(ProtectedSessionStorage protectedSessionStorage, IJwtTokenParser jwtTokenParser)
    {
        _protectedSessionStorage = protectedSessionStorage;
        _jwtTokenParser = jwtTokenParser;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var userSessionStorageResult = await _protectedSessionStorage.GetAsync<string>(SessionStorageConstants.UserSessionStorageKey);
        var userToken = userSessionStorageResult.Success ?
                        userSessionStorageResult.Value :
                        null;

        if(userToken == null)
        {
            return await Task.FromResult(new AuthenticationState(_anonymousPrincipals));
        }

        var claimPrincipal = _jwtTokenParser.ValidateTokenOrGetNull(userToken);

        if(claimPrincipal == null)
        {
            return await Task.FromResult(new AuthenticationState(_anonymousPrincipals));
        }
        
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimPrincipal)));

        return await Task.FromResult(new AuthenticationState(claimPrincipal));
    }

    public async Task UpdateAuthenticationState(UserSession userSession)
    {
        ClaimsPrincipal claimsPrincipal;

        if(userSession is not null)
        {
            await _protectedSessionStorage.SetAsync(SessionStorageConstants.UserSessionStorageKey, userSession);
            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimTypes.Email, userSession.Email),
                new Claim(ClaimTypes.Role, userSession.Role)
            }));
        }
        else
        {
            await _protectedSessionStorage.DeleteAsync(SessionStorageConstants.UserSessionStorageKey);
            claimsPrincipal = _anonymousPrincipals;
        }

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }
}
