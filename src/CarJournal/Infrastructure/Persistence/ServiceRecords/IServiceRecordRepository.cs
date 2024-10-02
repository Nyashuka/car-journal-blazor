using CarJournal.Domain;

namespace CarJournal.Infrastructure.Persistence.ServiceRecords;

public interface IServiceRecordRepository
{
    Task<ServiceRecord?> GetByIdAsync(int id);
    Task<List<ServiceRecord>> GetAllCarServicesAsync(int userCarId);
    Task AddAsync(ServiceRecord serviceRecord);
    Task UpdateAsync(ServiceRecord serviceRecord);
    Task DeleteAsync(int id);
}