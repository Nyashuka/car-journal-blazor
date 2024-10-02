using CarJournal.ClientDtos;
using CarJournal.Domain;
using CarJournal.Services.ServiceCategories;

using Microsoft.AspNetCore.Components;

using MudBlazor;

namespace CarJournal.Pages.AdminPanel.ServiceCategories;

public class ServiceCategoriesViewModel
{
    private readonly IServiceCategoryService _serviceCategory;
    private readonly NavigationManager _navigationManager;


    public List<ServiceCategory> ServiceCategories { get; private set; }

    public ServiceCategoriesViewModel(
        IServiceCategoryService serviceCategory,
        NavigationManager navigationManager)
    {
        _serviceCategory = serviceCategory;
        _navigationManager = navigationManager;
        ServiceCategories = new List<ServiceCategory>();
    }

    public async Task InitializeAsync()
    {
        ServiceCategories = await _serviceCategory.GetAllAsync();
    }

    public void NavigateToCreateServiceCategory()
    {
        _navigationManager.NavigateTo(UrlConstants.AdminCreateServiceCategory);
    }

    public Task DeleteRecord(ServiceCategory serviceCategory)
    {
        throw new NotImplementedException();
    }

    public Task OnSearch(string text)
    {
        throw new NotImplementedException();
    }

    public Task SaveItemChanges()
    {
        throw new NotImplementedException();
    }
}