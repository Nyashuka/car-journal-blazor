using CarJournal.Domain;
using CarJournal.Factories;
using CarJournal.Services.AutoMileageCalculator;
using CarJournal.Services.Mileages;
using CarJournal.Services.Notifications;
using CarJournal.Services.Trackings;

namespace CarJournal.Jobs;

public class DailyTrackingJob
{
    private readonly ITrackingService _trackingService;
    private readonly IMileageService _mileageService;

    public DailyTrackingJob(
        ITrackingService trackingService,
        IMileageService mileageService)
    {
        _trackingService = trackingService;
        _mileageService = mileageService;
    }

    public async Task ExecuteAsync()
    {
        EmailNotificationSender notificationSender
                    = new EmailNotificationSender("coc", "coc");

        MailMessageFactory mailMessageFactory
                    = new MailMessageFactory("cocer");

        var trackings = await _trackingService.GetTrackingsByParameters(TrackingType.Mileage);

        foreach(var tracking in trackings)
        {
            var lastMileage = await _mileageService.GetLastMileage(tracking.UserCarId);

            if(lastMileage == null || lastMileage.UpdatedAt.Date == DateTime.Now.Date)
            {
                continue;
            }

            if(tracking.MileageAtStart == null || tracking.UserCar == null)
                continue;

            tracking.UpdateMileage(
                lastMileage.Mileage - (int)tracking.MileageAtStart +
                tracking.UserCar.AverageMileage *
                (lastMileage.UpdatedAt.Date - DateTime.Now.Date).Days);

            await _trackingService.UpdateTrackingAsync(tracking);

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