
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;

using CarJournal.Persistence.Repositories;

namespace CarJournal.Services.Account;

public class AccountService : IAccountService
{
    private readonly IUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContext;

    public AccountService(IUserRepository userRepository, IHttpContextAccessor httpContext)
    {
        _userRepository = userRepository;
        _httpContext = httpContext;
    }

    public async Task ChangeEmail(int userId, string newEmail)
    {
        await _userRepository.ChangeUserEmail(userId, newEmail);
    }

    public async Task<ChangePasswordResult> ChangePassword(int userId, string oldPassword, string newPassword)
    {
        var user = await _userRepository.GetUserById(userId);

        if(user == null)
        {
            return new ChangePasswordResult()
            {
                IsSuccess = false,
                ErrorMessage = "User with given id is not Exists"
            };
        }

        if(!PasswordHasher.VerifyPasswordHash(oldPassword, user.PasswordHash, user.PasswordSalt))
        {
            return new ChangePasswordResult()
            {
                IsSuccess = false,
                ErrorMessage = "Old password is incorrect."
            };
        }

        PasswordHasher.CreatePasswordHash(newPassword, out byte[] newHash, out byte[] newSalt);

        user.ChangePassword(newHash, newSalt);

        await _userRepository.UpdateAsync(user);

        return new ChangePasswordResult()
        {
            IsSuccess = true
        };
    }

    public Task<bool> CheckPassword(int userId, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<string?> GetEmailByUserId(int userId)
    {

        return await _userRepository.GetEmailByUserId(userId);
    }

    private int? GetUserIdFromContext()
    {
        var stringId = _httpContext?.HttpContext?.User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

        return string.IsNullOrEmpty(stringId) ? null : Convert.ToInt32(stringId);
    }
}