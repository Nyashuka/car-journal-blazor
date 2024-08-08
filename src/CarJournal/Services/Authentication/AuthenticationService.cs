using CarJournal.Api.Authentication;
using CarJournal.Domain;
using CarJournal.Infrastructure.Authentication;
using CarJournal.Persistence.Repositories;

using Microsoft.Extensions.Configuration.UserSecrets;

namespace CarJournal.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string email, string password)
    {
        if(_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with giver email does not exists!");
        }

        return new AuthenticationResult(
            user.Id,
            user.Email,
            _jwtTokenGenerator.GenerateToken(user.Id)
        );
    }

    public AuthenticationResult Register(string email, string password)
    {
        if(_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists.");
        }

        User user = new User(email, password);

        _userRepository.Add(user);

        return new AuthenticationResult(
            user.Id,
            user.Email,
            _jwtTokenGenerator.GenerateToken(user.Id)
        );
    }
}
