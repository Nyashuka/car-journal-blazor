namespace CarJournal.Services.Account;

public interface IAccountService
{
    Task ChangeEmail(int userId, string newEmail);
    Task<ChangePasswordResult> ChangePassword(int userId, string oldPassword, string newPassword);
    Task<string?> GetEmailByUserId(int userId);
}