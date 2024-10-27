
using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;

namespace CarJournal.Infrastructure.Persistence.ServiceRecords;

public class ServiceRecordRepository : IServiceRecordRepository
{
    private readonly IDbContextFactory<CarJournalDbContext> _dbFactory;

    public ServiceRecordRepository(IDbContextFactory<CarJournalDbContext> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task AddAsync(ServiceRecord serviceRecord)
    {
        using (var context = await _dbFactory.CreateDbContextAsync())
        {
            context.ServiceRecords.Add(serviceRecord);
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        using (var context = await _dbFactory.CreateDbContextAsync())
        {
            var serviceRecord = await GetByIdAsync(id);

            if (serviceRecord == null)
            {
                return;
            }

            context.ServiceRecords.Remove(serviceRecord);
            await context.SaveChangesAsync();
        }
    }

    public async Task<List<ServiceRecord>> GetAllCarServicesAsync(int userCarId)
    {
        using (var context = await _dbFactory.CreateDbContextAsync())
        {
            return await context.ServiceRecords
                        .AsNoTracking()
                        .Where(r => r.UserCarId == userCarId)
                        .Include(r => r.ServiceCategory)
                        .ToListAsync();
        }
    }

    public async Task<ServiceRecord?> GetByIdAsync(int id)
    {
        using (var context = await _dbFactory.CreateDbContextAsync())
        {
            return await context.ServiceRecords.FirstOrDefaultAsync(r => r.Id == id);
        }
    }

    public async Task UpdateAsync(ServiceRecord serviceRecord)
    {
        using (var context = await _dbFactory.CreateDbContextAsync())
        {
            context.ServiceRecords.Update(serviceRecord);
            await context.SaveChangesAsync();
        }
    }
}
