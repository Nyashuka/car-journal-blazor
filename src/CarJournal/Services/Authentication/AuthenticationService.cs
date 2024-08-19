using CarJournal.Api.Authentication;
using CarJournal.Domain;
using CarJournal.Infrastructure.Authentication;
using CarJournal.Infrastructure.Persistence.Roles;
using CarJournal.Persistence.Repositories;

using Microsoft.Extensions.Configuration.UserSecrets;

namespace CarJournal.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _roleRepository = roleRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        if(_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with giver email does not exists!");
        }

        if(!PasswordHasher.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            throw new Exception("Password is incorrect!");
        }

        return new AuthenticationResult(
            user.Id,
            user.Email,
            _jwtTokenGenerator.GenerateToken(user.Id, user.Role.Name)
        );
    }

    public AuthenticationResult Register(string email, string password)
    {
        if(_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists.");
        }

        PasswordHasher.CreatePasswordHash(password,
                        out byte[] passwordHash,
                        out byte[] passwordSalt);

        var role = _roleRepository.GetById(RolesStorage.User.Id);
        
        User user = new User(email,
                        passwordHash, passwordSalt, role.Id, role);

        _userRepository.Add(user);

        return new AuthenticationResult(
            user.Id,
            user.Email,
            _jwtTokenGenerator.GenerateToken(user.Id, user.Role.Name)
        );
    }
}
