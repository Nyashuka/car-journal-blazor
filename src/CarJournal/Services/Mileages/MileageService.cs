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
        var validateData = await ValidateNewMileage(mileage.Mileage, mileage.UserCarId);
        if(validateData.IsValid)
        {
            var lastMileage = await GetLastMileage(mileage.UserCarId);

            if(lastMileage != null &&
                lastMileage.UpdatedAt.Date == DateTime.Now.Date)
            {
                lastMileage.UpdateData(mileage.Mileage, DateTime.UtcNow);
                await UpdateMileageRecordAsync(lastMileage);
            }
            else
            {
                await _mileageRepository.AddAsync(mileage);
            }
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
        var mileages = await GetAllAsync(userCarId);
        var lastMileage = await GetLastMileage(userCarId);
        if(mileages.Count > 1 &&
            lastMileage != null &&
            lastMileage.UpdatedAt.Date != DateTime.Now.Date &&
            newMileage <= lastMileage.Mileage)
        {
            return new MileageValidationResult(false, "Mileage must be greater than last record");
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