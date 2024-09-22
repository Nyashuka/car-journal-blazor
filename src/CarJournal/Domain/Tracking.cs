namespace CarJournal.Domain;

public class Tracking
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public TrackingType TrackingType { get; private set; }
    public DateTime? EndDate { get; private set; }
    public int TotalMileage { get; private set; }
    public int? LimitMileage { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
}