using System.Net;
using System.Net.Mail;

namespace CarJournal.Services.Notifications;

public class EmailNotificationSender
{
    private readonly SmtpClient _smtpClient;

    public EmailNotificationSender(string senderMailAddress, string emailPassword)
    {

        _smtpClient = new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new NetworkCredential(senderMailAddress, emailPassword),
            EnableSsl = true
        };
    }

    public void SendMail(MailMessage mailMessage)
    {
        _smtpClient.Send(mailMessage);
    }
}