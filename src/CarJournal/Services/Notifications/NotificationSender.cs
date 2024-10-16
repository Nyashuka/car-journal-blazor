using System.Net;
using System.Net.Mail;

namespace CarJournal.Services.Notifications;

public class NotificationSender
{
    private readonly SmtpClient _smtpClient;

    public NotificationSender(string senderMailAddress, string emailPassword)
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