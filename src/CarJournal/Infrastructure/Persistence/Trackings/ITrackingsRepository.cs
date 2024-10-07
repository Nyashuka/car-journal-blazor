using CarJournal.Domain;

namespace CarJournal.Infrastructure.Persistence.Trackings;

public interface ITrackingsRepository
{
    Task<Tracking?> GetByIdAsync(int id);
    Task<List<Tracking>> GetAllByCarIdAsync(int carId);
    Task AddAsync(Tracking tracking);
    Task UpdateAsync(Tracking tracking);
    Task DeleteAsync(int id);
}