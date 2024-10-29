namespace CarJournal.ClientDtos;

public class UpdateTrackingDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string MessageForReminder { get; set; } = string.Empty;
}