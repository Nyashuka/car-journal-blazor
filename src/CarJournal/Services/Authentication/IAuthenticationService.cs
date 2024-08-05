using CarJournal.Api.Authentication;

namespace CarJournal.Services.Authentication;

public interface IAuthenticationService
{
    public AuthenticationResponse Register(string email, string password);
    public AuthenticationResponse Login(string email, string password);
}