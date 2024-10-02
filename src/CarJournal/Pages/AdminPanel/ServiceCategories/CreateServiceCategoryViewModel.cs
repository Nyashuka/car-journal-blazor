namespace CarJournal.Pages.AdminPanel.ServiceCategories;

using CarJournal.Domain;
using CarJournal.Services.ServiceCategories;

using Microsoft.AspNetCore.Components;

public class CreateServiceCategoryViewModel
{
    private readonly IServiceCategoryService _categoryService;
    private readonly NavigationManager _navigationManager;
    public string CategoryName { get; set; } = string.Empty;

    public CreateServiceCategoryViewModel(
        IServiceCategoryService categoryService,
        NavigationManager navigationManager)
    {
        _categoryService = categoryService;
        _navigationManager = navigationManager;
    }

    public async Task CreateCategory()
    {
        await _categoryService.AddServiceCategoryAsync(
            new ServiceCategory(0, CategoryName));
        NavigateBackToCategoriesList();
    }

    public void NavigateBackToCategoriesList()
    {
        _navigationManager.NavigateTo(UrlConstants.AdminServiceCategoriesList);
    }
}