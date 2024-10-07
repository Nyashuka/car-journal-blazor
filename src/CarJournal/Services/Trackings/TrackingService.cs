using CarJournal.Domain;
using CarJournal.Infrastructure.Persistence.Trackings;

namespace CarJournal.Services.Trackings;

public class TrackingService : ITrackingService
{
    private readonly ITrackingsRepository _trackingsRepository;

    public TrackingService(ITrackingsRepository trackingsRepository)
    {
        _trackingsRepository = trackingsRepository;
    }

    public async Task AddTrackingAsync(Tracking tracking)
    {
        await _trackingsRepository.AddAsync(tracking);
    }

    public async Task DeleteTrackingAsync(int id)
    {
        await _trackingsRepository.DeleteAsync(id);
    }

    public async Task<List<Tracking>> GetAllTrackingsByCarIdAsync(int userCarId)
    {
        return await _trackingsRepository.GetAllByCarIdAsync(userCarId);
    }

    public async Task<Tracking?> GetByIdAsync(int id)
    {
        return await _trackingsRepository.GetByIdAsync(id);
    }

    public async Task UpdateTrackingAsync(Tracking tracking)
    {
        await _trackingsRepository.UpdateAsync(tracking);
    }
}