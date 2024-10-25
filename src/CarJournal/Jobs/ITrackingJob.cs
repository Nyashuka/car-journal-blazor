namespace CarJournal.Jobs;

public interface IDailyTrackingJob
{
    Task ExecuteAsync();
}