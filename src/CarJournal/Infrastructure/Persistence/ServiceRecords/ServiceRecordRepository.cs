
using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;

namespace CarJournal.Infrastructure.Persistence.ServiceRecords;

public class ServiceRecordRepository : IServiceRecordRepository
{
    private readonly CarJournalDbContext _dbContext;

    public ServiceRecordRepository(CarJournalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(ServiceRecord serviceRecord)
    {
        _dbContext.ServiceRecords.Add(serviceRecord);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var serviceRecord = await GetByIdAsync(id);

        if(serviceRecord == null)
        {
            return;
        }

        _dbContext.ServiceRecords.Remove(serviceRecord);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<ServiceRecord>> GetAllCarServicesAsync(int userCarId)
    {
        return await _dbContext.ServiceRecords
                        .AsNoTracking()
                        .Where(r => r.UserCarId == userCarId)
                        .ToListAsync();
    }

    public async Task<ServiceRecord?> GetByIdAsync(int id)
    {
        return await _dbContext.ServiceRecords.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task UpdateAsync(ServiceRecord serviceRecord)
    {
        _dbContext.ServiceRecords.Update(serviceRecord);
        await _dbContext.SaveChangesAsync();
    }
}
