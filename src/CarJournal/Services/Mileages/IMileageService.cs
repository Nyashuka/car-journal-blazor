using CarJournal.Domain;

namespace CarJournal.Services.Mileages;

public interface IMileageService
{
    Task<MileageRecord?> GetByIdAsync(int id);
    Task<List<MileageRecord>> GetAllAsync(int userCarId);
    Task<MileageRecord?> GetLastMileage(int userCarId);
    Task AddMileageRecordAsync(MileageRecord mileage);
    Task UpdateMileageRecordAsync(MileageRecord mileage);
    Task DeleteMileageRecordAsync(int id);
}