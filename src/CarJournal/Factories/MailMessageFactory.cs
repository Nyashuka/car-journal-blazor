using System.Net.Mail;

using CarJournal.Domain;

namespace CarJournal.Factories;

public class MailMessageFactory
{
    private readonly string _senderMailAddress;

    public MailMessageFactory(string senderMailAddress)
    {
        _senderMailAddress = senderMailAddress;
    }

    public MailMessage Create(User user, Tracking tracking)
    {
        MailMessage mailMessage = new MailMessage
        {
            From = new MailAddress(_senderMailAddress),
            Subject = tracking.Name,
            Body = tracking.MessageForReminder,
            IsBodyHtml = false,
        };

        mailMessage.To.Add(user.Email);

        return mailMessage;
    }
}