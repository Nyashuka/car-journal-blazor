
using CarJournal.Domain;
using CarJournal.Infrastructure.Persistence.ServiceCategories;

namespace CarJournal.Services.ServiceCategories;

public class ServiceCategoryService : IServiceCategoryService
{
    private readonly IServiceCategoryRepository _categoryRepository;

    public ServiceCategoryService(IServiceCategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task AddServiceCategoryAsync(ServiceCategory category)
    {
        await _categoryRepository.AddAsync(category);
    }

    public async Task DeleteServiceCategoryAsync(int id)
    {
        await _categoryRepository.DeleteAsync(id);
    }

    public async Task<List<ServiceCategory>> GetAllAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async Task<ServiceCategory?> GetByIdAsync(int id)
    {
        return await _categoryRepository.GetByIdAsync(id);
    }

    public async Task UpdateServiceCategoryAsync(ServiceCategory category)
    {
        await _categoryRepository.UpdateAsync(category);
    }
}