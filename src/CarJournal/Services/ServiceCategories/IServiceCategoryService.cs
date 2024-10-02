using CarJournal.Domain;

namespace CarJournal.Services.ServiceCategories;

public interface IServiceCategoryService
{
    Task<ServiceCategory?> GetByIdAsync(int id);
    Task<List<ServiceCategory>> GetAllAsync();
    Task AddServiceCategoryAsync(ServiceCategory category);
    Task UpdateServiceCategoryAsync(ServiceCategory category);
    Task DeleteServiceCategoryAsync(int id);
}