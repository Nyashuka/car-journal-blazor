using CarJournal.Domain;

namespace CarJournal.ClientDtos;

public class CreateTrackingDto
{
    public string Name { get; set; } = string.Empty;
    public string MessageForReminder { get; set; } = string.Empty;
    public int UserCarId { get; set; }
    public TrackingType TrackingType { get; set; }
    public DateTime? EndDate { get; set; }
    public int? MileageAtStart { get; set; }
    public int? TotalMileage { get; set; }
    public int? LimitMileage { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}