namespace CarJournal.Services.Account;

public interface IAccountService
{
    Task ChangeEmail(int userId, string newEmail);
    Task<string> GetEmailByUserId(int userId);
}