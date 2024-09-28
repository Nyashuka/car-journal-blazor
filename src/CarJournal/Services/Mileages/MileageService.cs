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

    public async Task UpdateMileageRecordAsync(MileageRecord mileage)
    {
        await _mileageRepository.UpdateAsync(mileage);
    }
}