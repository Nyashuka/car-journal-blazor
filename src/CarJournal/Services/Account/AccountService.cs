
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
        var requestUserId = _httpContext.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
 
        if(requestUserId == null)
        {
            return;
        }
    }

    public Task<string> GetEmailByUserId(int userId)
    {
        throw new NotImplementedException();
    }
}