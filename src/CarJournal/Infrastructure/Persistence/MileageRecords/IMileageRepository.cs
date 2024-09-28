using CarJournal.Domain;

namespace CarJournal.Infrastructure.Persistence.MileageRecords;

public interface IMileageRepository
{
    Task<MileageRecord?> GetByIdAsync(int id);
    Task<List<MileageRecord>> GetAllAsync(int userCarId);
    Task AddAsync(MileageRecord mileage);
    Task UpdateAsync(MileageRecord mileage);
    Task DeleteAsync(int id);
}