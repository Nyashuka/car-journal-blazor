using CarJournal.Domain;
using CarJournal.Factories;
using CarJournal.Services.AutoMileageCalculator;
using CarJournal.Services.Mileages;
using CarJournal.Services.Notifications;
using CarJournal.Services.Trackings;

namespace CarJournal.Jobs;

public class DailyMileageTrackingJob
{
    private readonly ITrackingService _trackingService;
    private readonly IMileageService _mileageService;

    public DailyMileageTrackingJob(
        ITrackingService trackingService,
        IMileageService mileageService)
    {
        _trackingService = trackingService;
        _mileageService = mileageService;
    }

    public async Task ExecuteAsync()
    {
        EmailNotificationSender notificationSender
                    = new EmailNotificationSender();

        MailMessageFactory mailMessageFactory
                    = new MailMessageFactory(notificationSender.GetEmailAddress);

        var trackings = await _trackingService
            .GetTrackingsByParameters(TrackingType.Mileage);

        foreach(var tracking in trackings)
        {
            var lastMileage = await _mileageService.GetLastMileage(tracking.UserCarId);

            if(lastMileage == null ||
                lastMileage.UpdatedAt.Date == DateTime.Now.Date)
            {
                continue;
            }

            if(tracking.UserCar == null)
                continue;

            var daysCountFromLastMileage =
                (DateTime.Now.Date - lastMileage.UpdatedAt.Date).Days;

            var mileageDelta = lastMileage.Mileage - tracking.MileageAtStart;
            var newTotalMileage = mileageDelta +
                tracking.UserCar.AverageMileage * daysCountFromLastMileage;

            tracking.UpdateMileage(newTotalMileage);

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