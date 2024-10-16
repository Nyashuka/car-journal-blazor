using CarJournal.Domain;
using CarJournal.Infrastructure.Persistence.MileageRecords;

namespace CarJournal.Services.Mileages;

public class MileageService : IMileageService
{
    private readonly IMileageRepository _mileageRepository;

    public MileageService(IMileageRepository mileageRepository)
    {
        _mileageRepository = mileageRepository;
    }

    public async Task AddMileageRecordAsync(MileageRecord mileage)
    {
        var lastMileage = await _mileageRepository.GetLastMileage(mileage.UserCarId);

        if(lastMileage != null && lastMileage.UpdatedAt.Date == DateTime.Today)
        {
            lastMileage.UpdateData(mileage.Mileage, DateTime.UtcNow);
            await UpdateMileageRecordAsync(lastMileage);
            return;
        }

        await _mileageRepository.AddAsync(mileage);
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

    public async Task UpdateMileageRecordAsync(MileageRecord mileage)
    {
        await _mileageRepository.UpdateAsync(mileage);
    }
}