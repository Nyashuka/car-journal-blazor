using CarJournal.Domain;

namespace CarJournal.Services.Trackings;

public interface ITrackingService
{
    Task<Tracking?> GetByIdAsync(int id);
    Task<List<Tracking>> GetAllTrackingsByCarIdAsync(int userCarId, TrackingType? type);
    Task AddTrackingAsync(Tracking tracking);
    Task UpdateTrackingAsync(Tracking tracking);
    Task DeleteTrackingAsync(int id);
    Task<List<Tracking>> GetTrackingsByParameters(TrackingType? type);
    Task UpdateMileageTracking(int userCarId);
}