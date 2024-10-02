using CarJournal.Domain;

namespace CarJournal.Infrastructure.Persistence.ServiceCategories;

public interface IServiceCategoryRepository
{
    Task<ServiceCategory?> GetByIdAsync(int id);
    Task<List<ServiceCategory>> GetAllAsync();
    Task AddAsync(ServiceCategory category);
    Task UpdateAsync(ServiceCategory category);
    Task DeleteAsync(int id);
}