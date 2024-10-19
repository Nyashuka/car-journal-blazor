using CarJournal.Domain;
using CarJournal.Infrastructure.Persistence.MileageRecords;
using CarJournal.Infrastructure.Persistence.Trackings;

namespace CarJournal.Services.Trackings;

public class TrackingService : ITrackingService
{
    private readonly ITrackingsRepository _trackingsRepository;
    private readonly IMileageRepository _mileageRepository;

    public TrackingService(
        ITrackingsRepository trackingsRepository,
        IMileageRepository mileageRepository)
    {
        _trackingsRepository = trackingsRepository;
        _mileageRepository = mileageRepository;
    }

    public async Task AddTrackingAsync(Tracking tracking)
    {
        await _trackingsRepository.AddAsync(tracking);
    }

    public async Task DeleteTrackingAsync(int id)
    {
        await _trackingsRepository.DeleteAsync(id);
    }

    public async Task<List<Tracking>> GetAllTrackingsByCarIdAsync(int userCarId, TrackingType? type)
    {
        return await _trackingsRepository.GetAllByCarIdAsync(userCarId, type);
    }

    public async Task<Tracking?> GetByIdAsync(int id)
    {
        return await _trackingsRepository.GetByIdAsync(id);
    }

    public async Task<List<Tracking>> GetTrackingsByParameters(TrackingType? type)
    {
        return await _trackingsRepository.GetByParameters(type);
    }

    public async Task UpdateTrackingAsync(Tracking tracking)
    {
        await _trackingsRepository.UpdateAsync(tracking);
    }

    public async Task UpdateMileageTracking(int userCarId)
    {
        var trackings = await GetAllTrackingsByCarIdAsync(userCarId, TrackingType.Mileage);
        var lastMileage = await _mileageRepository.GetLastMileage(userCarId);

        if(lastMileage == null)
            return;

        foreach(var tracking in trackings)
        {
            tracking.UpdateMileage(
                Convert.ToInt32(lastMileage.Mileage - tracking.MileageAtStart)
            );

            await UpdateTrackingAsync(tracking);
        }
    }
}