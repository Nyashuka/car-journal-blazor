using CarJournal.Domain;
using CarJournal.Infrastructure.Persistence.MileageRecords;
using CarJournal.Infrastructure.Persistence.Trackings;

using MudBlazor;

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

    public async Task UpdateTotalMileage(MileageRecord mileageRecord)
    {
        var trackings =
            await GetAllTrackingsByCarIdAsync(mileageRecord.UserCarId, TrackingType.Mileage);

        foreach(var tracking in trackings)
        {
            tracking.UpdateMileage(
                Convert.ToInt32(mileageRecord.Mileage - tracking.MileageAtStart)
            );

            await UpdateTrackingAsync(tracking);
        }
    }

    public async Task ResetTracking(int trackingId)
    {
        var tracking = await GetTrackingById(trackingId);

        var lastMileage = await _mileageRepository.GetLastMileage(tracking.UserCarId);

        if(lastMileage != null && lastMileage.UpdatedAt.Date == DateTime.Today.Date)
        {
            tracking.Reset(lastMileage.Mileage);
            await UpdateTrackingAsync(tracking);
        }
    }

    public async Task<Tracking?> GetTrackingById(int trackingId)
    {
        return await _trackingsRepository.GetByIdAsync(trackingId);
    }

    public async Task<List<Tracking>> GetTrackingsReachedLimit(int userCarId)
    {
        return await _trackingsRepository.GetTrackingsReachedLimit(userCarId);
    }
}