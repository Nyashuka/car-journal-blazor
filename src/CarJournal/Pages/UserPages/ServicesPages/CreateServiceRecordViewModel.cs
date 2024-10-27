using CarJournal.ClientDtos;
using CarJournal.Domain;
using CarJournal.Services.Client;
using CarJournal.Services.ServiceCategories;
using CarJournal.Services.ServiceRecords;

using Microsoft.AspNetCore.Components;

namespace CarJournal.Pages.UserPages.ServicesPages;

public class CreateServiceRecordViewModel
{
    private readonly IServiceCategoryService _serviceCategoryService;
    private readonly IServiceRecordService _serviceRecordService;
    private readonly ISelectedCarService _selectedCarService;
    private readonly NavigationManager _navigationManger;

    public CreateServiceRecordDto CreateServiceRecordDto { get; set; } = new();
    public List<ServiceCategory> ServiceCategories { get; set; } = new();

    public CreateServiceRecordViewModel(
        IServiceCategoryService serviceCategoryService,
        IServiceRecordService serviceRecordService,
        ISelectedCarService selectedCarService,
        NavigationManager navigationManger)
    {
        _serviceCategoryService = serviceCategoryService;
        _serviceRecordService = serviceRecordService;
        _selectedCarService = selectedCarService;
        _navigationManger = navigationManger;
    }

    public async Task InitializeAsync()
    {
        ServiceCategories = await _serviceCategoryService.GetAllAsync();
    }

    public async Task CreateRecord()
    {
        if(CreateServiceRecordDto.ServiceCategory == null)
        {
            return;
        }

        var selectedCar = await _selectedCarService.GetSelectedCar();

        await _serviceRecordService.AddServiceRecordAsync(
            new ServiceRecord(
                0,
                CreateServiceRecordDto.Title,
                CreateServiceRecordDto.ServiceCategory.Id,
                selectedCar.Id,
                CreateServiceRecordDto.Mileage,
                CreateServiceRecordDto.Price,
                CreateServiceRecordDto.Description,
                CreateServiceRecordDto.DateOfService ?? DateTime.Now,
                null,
                null
            )
        );

        NavigateBackToServicesList();
    }

    public void NavigateBackToServicesList()
    {
        _navigationManger.NavigateTo(UrlConstants.ServiceRecordList);
    }

    public async Task<IEnumerable<ServiceCategory>> SearchCategory(string value, CancellationToken token)
    {
        await Task.Delay(5, token);

        if (string.IsNullOrEmpty(value))
            return ServiceCategories;

        return ServiceCategories.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }
}