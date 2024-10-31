using CarJournal.Domain;
using CarJournal.Factories;
using CarJournal.Services.Notifications;
using CarJournal.Services.Trackings;

namespace CarJournal.Jobs;

public class DailyDateTrackingJob : IDailyTrackingJob
{
    private readonly ITrackingService _trackingService;

    public DailyDateTrackingJob(ITrackingService trackingService)
    {
        _trackingService = trackingService;
    }

    public async Task ExecuteAsync()
    {
        EmailNotificationSender notificationSender
                    = new EmailNotificationSender();

        MailMessageFactory mailMessageFactory
                    = new MailMessageFactory(notificationSender.GetEmailAddress);

        var trackings = await _trackingService
            .GetTrackingsByParameters(TrackingType.Date);

        foreach(var tracking in trackings)
        {
            if(tracking.UserCar == null)
                continue;

            if(tracking.IsLimitReached())
            {
                try
                {
                    var mail = mailMessageFactory.Create(tracking.UserCar.User, tracking);

                    notificationSender.SendMail(mail);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}