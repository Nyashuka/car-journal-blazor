namespace CarJournal.Services.Account;

public class ChangePasswordResult
{
    public bool IsSuccess { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
}