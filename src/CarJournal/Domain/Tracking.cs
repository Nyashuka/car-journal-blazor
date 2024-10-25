namespace CarJournal.Domain;

public class Tracking
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string MessageForReminder { get; private set; } = string.Empty;
    public int UserCarId { get; private set; }
    public UserCar? UserCar { get; private set; }
    public TrackingType TrackingType { get; private set; }
    public DateTime? EndDate { get; private set; }
    public int MileageAtStart { get; private set; }
    public int? TotalMileage { get; private set; }
    public int? LimitMileage { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Tracking() {}

    public Tracking(
        int id,
        string name,
        string messageForReminder,
        int userCarId,
        UserCar? userCar,
        TrackingType trackingType,
        DateTime createdAt,
        int mileageAtStart,
        int? totalMileage = 0,
        int? limitMileage = null,
        DateTime? endDate = null)
    {
        Id = id;
        Name = name;
        MessageForReminder = messageForReminder;
        UserCarId = userCarId;
        UserCar = userCar;
        TrackingType = trackingType;
        CreatedAt = createdAt.ToUniversalTime();
        UpdatedAt = DateTime.UtcNow;

        if (trackingType == TrackingType.Mileage && limitMileage == null)
            throw new ArgumentException("Limit mileage is required for mileage tracking.");

        if (trackingType == TrackingType.Date && endDate == null)
            throw new ArgumentException("End date is required for date tracking.");

        TotalMileage = totalMileage;
        LimitMileage = limitMileage;
        MileageAtStart = mileageAtStart;

        if(endDate.HasValue)
            EndDate = endDate.Value.ToUniversalTime();
    }

    public void Reset(int newStartMileage)
    {
        TotalMileage = 0;
        MileageAtStart = newStartMileage;
        UpdatedAt = DateTime.UtcNow;
        CreatedAt = UpdatedAt;
    }

    public void Update(Tracking tracking)
    {
        Name = tracking.Name;
        MessageForReminder = tracking.MessageForReminder;
        UpdatedAt = tracking.UpdatedAt;
        CreatedAt = tracking.CreatedAt;
        TotalMileage = tracking.TotalMileage;
        LimitMileage = tracking.LimitMileage;
        MileageAtStart = tracking.MileageAtStart;
    }

    public void UpdateMileage(int mileage)
    {
        if (TrackingType != TrackingType.Mileage)
            throw new InvalidOperationException("Cannot update mileage for a non-mileage tracking type.");

        TotalMileage = mileage;
        UpdatedAt = DateTime.Now;
    }

    public bool IsLimitReached()
    {
        return TrackingType switch
        {
            TrackingType.Mileage => LimitMileage.HasValue && TotalMileage >= LimitMileage.Value,
            TrackingType.Date => EndDate.HasValue && DateTime.Today.Date >= EndDate.Value.Date,
            _ => false,
        };
    }

    public double GetMileagePercentageProgress()
    {
        if(TrackingType != TrackingType.Mileage)
            return 0;

        return Convert.ToDouble(TotalMileage) / Convert.ToDouble(LimitMileage) * 100;
    }
}