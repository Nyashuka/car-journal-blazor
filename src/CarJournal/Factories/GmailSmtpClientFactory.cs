using System.Net;
using System.Net.Mail;

namespace CarJournal.Factories;

public class GmailSmtpClientFactory
{
    private const string GMAIL_LOGIN_VARIABLE = "GMAIL_USERNAME";
    private const string GMAIL_PASSWORD_VARIABLE = "GMAIL_PASSWORD";
    public string EmailAddress { get; private set; }

    public SmtpClient CreateAuthorizedClient()
    {
        var login = Environment.GetEnvironmentVariable(GMAIL_LOGIN_VARIABLE);
        var password = Environment.GetEnvironmentVariable(GMAIL_PASSWORD_VARIABLE);

        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
        {
            throw new InvalidOperationException("Gmail credentials are not set in the environment variables.");
        }

        EmailAddress = login;

        return new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new NetworkCredential(login, password),
            EnableSsl = true
        };
    }
}