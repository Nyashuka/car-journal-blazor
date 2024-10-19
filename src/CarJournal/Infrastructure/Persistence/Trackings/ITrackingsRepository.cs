using CarJournal.Domain;

namespace CarJournal.Infrastructure.Persistence.Trackings;

public interface ITrackingsRepository
{
    Task<Tracking?> GetByIdAsync(int id);
    Task<List<Tracking>> GetAllByCarIdAsync(int carId, TrackingType? type);
    Task AddAsync(Tracking tracking);
    Task UpdateAsync(Tracking tracking);
    Task DeleteAsync(int id);
    Task<List<Tracking>> GetByParameters(TrackingType? type);
}