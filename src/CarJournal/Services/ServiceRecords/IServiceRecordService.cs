using CarJournal.Domain;

namespace CarJournal.Services.ServiceRecords;

public interface IServiceRecordService
{
    Task<ServiceRecord?> GetByIdAsync(int id);
    Task<List<ServiceRecord>> GetAllCarServicesAsync(int userCarId);
    Task AddServiceRecordAsync(ServiceRecord serviceRecord);
    Task UpdateServiceRecordAsync(ServiceRecord serviceRecord);
    Task DeleteServiceRecordAsync(int id);
}