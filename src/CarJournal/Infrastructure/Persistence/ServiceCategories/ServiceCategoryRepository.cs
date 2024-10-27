
using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;

namespace CarJournal.Infrastructure.Persistence.ServiceCategories;

public class ServiceCategoryRepository : IServiceCategoryRepository
{
    private readonly IDbContextFactory<CarJournalDbContext> _dbFactory;

    public ServiceCategoryRepository(IDbContextFactory<CarJournalDbContext> dbContext)
    {
        _dbFactory = dbContext;
    }

    public async Task AddAsync(ServiceCategory category)
    {
        using(var context = _dbFactory.CreateDbContext())
        {
            context.ServiceCategories.Add(category);
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        using(var context = _dbFactory.CreateDbContext())
        {
            var category = context.ServiceCategories.FirstOrDefault(c => c.Id == id);

            if (category != null)
            {
                context.Remove(category);
                await context.SaveChangesAsync();
            }
        }
    }

    public async Task<List<ServiceCategory>> GetAllAsync()
    {
        using(var context = _dbFactory.CreateDbContext())
        {
            return await context.ServiceCategories.ToListAsync();
        }
    }

    public Task<ServiceCategory?> GetByIdAsync(int id)
    {
        using(var context = _dbFactory.CreateDbContext())
        {
            return context.ServiceCategories.FirstOrDefaultAsync(c => c.Id == id);
        }
    }

    public async Task UpdateAsync(ServiceCategory category)
    {
        using(var context = _dbFactory.CreateDbContext())
        {
            context.ServiceCategories.Update(category);
            await context.SaveChangesAsync();
        }
    }
}
