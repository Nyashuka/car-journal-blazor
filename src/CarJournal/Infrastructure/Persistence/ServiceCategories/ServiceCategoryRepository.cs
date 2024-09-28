
using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;

namespace CarJournal.Infrastructure.Persistence.ServiceCategories;

public class ServiceCategoryRepository : IServiceCategoryRepository
{
    private readonly CarJournalDbContext _dbContext;

    public ServiceCategoryRepository(CarJournalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(ServiceCategory category)
    {
        _dbContext.ServiceCategories.Add(category);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var category = _dbContext.ServiceCategories.FirstOrDefault(c => c.Id == id);

        if(category != null)
        {
            _dbContext.Remove(category);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<List<ServiceCategory>> GetAllAsync()
    {
        return await _dbContext.ServiceCategories.ToListAsync();
    }

    public Task<ServiceCategory?> GetByIdAsync(int id)
    {
        return _dbContext.ServiceCategories.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task UpdateAsync(ServiceCategory category)
    {
        _dbContext.ServiceCategories.Update(category);
        await _dbContext.SaveChangesAsync();
    }
}
