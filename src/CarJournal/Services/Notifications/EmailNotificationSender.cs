using System.Net.Mail;

using CarJournal.Factories;

namespace CarJournal.Services.Notifications;

public class EmailNotificationSender
{
    private readonly GmailSmtpClientFactory _authDataReader;
    private readonly SmtpClient _smtpClient;
    public string GetEmailAddress => _authDataReader.EmailAddress;

    public EmailNotificationSender()
    {
        _authDataReader = new GmailSmtpClientFactory();

        _smtpClient = _authDataReader.CreateAuthorizedClient();
    }

    public void SendMail(MailMessage mailMessage)
    {
        _smtpClient.Send(mailMessage);
    }
}