using CarJournal.Api.Authentication;

namespace CarJournal.Services.Authentication;

public interface IAuthenticationService
{
    Task<AuthenticationResult> Register(string email, string password);
    Task<AuthenticationResult> Login(string email, string password);
}