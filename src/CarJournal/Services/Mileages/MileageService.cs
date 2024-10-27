using CarJournal.Domain;
using CarJournal.Infrastructure.Persistence.MileageRecords;
using CarJournal.Services.Trackings;
using CarJournal.Services.UserCars;

namespace CarJournal.Services.Mileages;

public class MileageService : IMileageService
{
    private readonly ITrackingService _trackingService;
    private readonly IMileageRepository _mileageRepository;
    private readonly IUserCarsService _userCarsService;

    public MileageService(
        IMileageRepository mileageRepository,
        ITrackingService trackingService,
        IUserCarsService userCarsService)
    {
        _mileageRepository = mileageRepository;
        _trackingService = trackingService;
        _userCarsService = userCarsService;
    }

    public async Task DeleteMileageRecordAsync(int id)
    {
        await _mileageRepository.DeleteAsync(id);
    }

    public async Task<List<MileageRecord>> GetAllAsync(int userCarId)
    {
        return await _mileageRepository.GetAllAsync(userCarId);
    }

    public async Task<MileageRecord?> GetByIdAsync(int id)
    {
        return await _mileageRepository.GetByIdAsync(id);
    }

    public async Task<MileageRecord?> GetLastMileage(int userCarId)
    {
        return await _mileageRepository.GetLastMileage(userCarId);
    }

    public async Task AddMileageRecordAsync(MileageRecord mileage)
    {
        if(mileage.Mileage < 0)
            throw new Exception("\nMILEAGE CANT BE LESS THAN 0\n");

        var lastMileage =
            await _mileageRepository.GetLastMileage(mileage.UserCarId);

        var trackings =
            await _trackingService.GetAllTrackingsByCarIdAsync(mileage.UserCarId, TrackingType.Mileage);

        if(lastMileage == null ||
            lastMileage.UpdatedAt.Date < DateTime.Today.Date &&
            mileage.Mileage > lastMileage.Mileage)
        {
            await _mileageRepository.AddAsync(mileage);
            await _trackingService.UpdateTotalMileage(mileage);
            return;
        }

        if(lastMileage.UpdatedAt.Date == DateTime.Today &&
            mileage.Mileage > lastMileage.Mileage)
        {
            var biggestStartMileageTracking = trackings
                .Where(t => t.CreatedAt.Date == DateTime.Today.Date)
                .OrderByDescending(t => t.MileageAtStart)
                .FirstOrDefault();

            if(biggestStartMileageTracking != null &&
                biggestStartMileageTracking.MileageAtStart >= mileage.Mileage)
                {
                    throw new Exception("\nCan't set mileage less than existing Tracking's mileage at start");
                }

            lastMileage.UpdateData(mileage.Mileage, DateTime.UtcNow);
            await UpdateMileageRecordAsync(lastMileage);
            await _trackingService.UpdateTotalMileage(mileage);
        }
    }

    public async Task UpdateMileageRecordAsync(MileageRecord mileage)
    {
        await _mileageRepository.UpdateAsync(mileage);
    }

    public async Task<MileageValidationResult> ValidateNewMileage(int newMileage, int userCarId)
    {
        // ---
        if(newMileage < 0)
            return new MileageValidationResult(false, "Mileage can't be less than 0");

        // ---
        var trackings = await _trackingService
            .GetAllTrackingsByCarIdAsync(userCarId, TrackingType.Mileage);

        if(trackings.Count > 0)
        {
            var maxTrackingMileage = trackings.Max(t => t.MileageAtStart);

            if(maxTrackingMileage >= newMileage)
            {
                return new MileageValidationResult(false, "Mileage can't be less than exists tracking's start mileage");
            }
        }

        // ---
        var userCar = await _userCarsService.GetByIdAsync(userCarId);
        if(userCar != null && userCar.StartMileage >= newMileage)
        {
            return new MileageValidationResult(false, "Mileage must be greater than start car mileage");
        }

        // ---
        return new MileageValidationResult(true);
    }
}