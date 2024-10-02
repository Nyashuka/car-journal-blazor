
using CarJournal.Domain;
using CarJournal.Infrastructure.Persistence.ServiceRecords;

namespace CarJournal.Services.ServiceRecords;

public class ServiceRecordService : IServiceRecordService
{
    private readonly IServiceRecordRepository _serviceRecordRepository;

    public ServiceRecordService(IServiceRecordRepository serviceRecordRepository)
    {
        _serviceRecordRepository = serviceRecordRepository;
    }

    public async Task AddServiceRecordAsync(ServiceRecord serviceRecord)
    {
        await _serviceRecordRepository.AddAsync(serviceRecord);
    }

    public async Task DeleteServiceRecordAsync(int id)
    {
        await _serviceRecordRepository.DeleteAsync(id);
    }

    public async Task<List<ServiceRecord>> GetAllCarServicesAsync(int userCarId)
    {
        return await _serviceRecordRepository.GetAllCarServicesAsync(userCarId);
    }

    public async Task<ServiceRecord?> GetByIdAsync(int id)
    {
        return await _serviceRecordRepository.GetByIdAsync(id);
    }

    public async Task UpdateServiceRecordAsync(ServiceRecord serviceRecord)
    {
        await _serviceRecordRepository.UpdateAsync(serviceRecord);
    }
}