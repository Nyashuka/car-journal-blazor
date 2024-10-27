using CarJournal.ClientDtos;
using CarJournal.Domain;
using CarJournal.Services.Client;
using CarJournal.Services.ServiceCategories;
using CarJournal.Services.ServiceRecords;

using Microsoft.AspNetCore.Components;

namespace CarJournal.Pages.UserPages.ServicesPages;

public class ServiceRecordsListViewModel
{
    private readonly IServiceRecordService _serviceRecordService;
    private readonly ISelectedCarService _selectedCarService;
    private readonly NavigationManager _navigationManager;

    public List<ServiceRecord> ServiceRecords { get; private set; }
    public List<ServiceCategory> ServiceCategories { get; private set; }

    public ServiceRecordsListViewModel(
        IServiceRecordService serviceRecordService,
        ISelectedCarService selectedCarService,
        NavigationManager navigationManager)
    {
        _serviceRecordService = serviceRecordService;
        ServiceRecords = new List<ServiceRecord>();
        _selectedCarService = selectedCarService;
        _navigationManager = navigationManager;
    }

    public async Task InitializeAsync(int? categoryId)
    {
        var selectedCar = await _selectedCarService.GetSelectedCar();

        ServiceRecords = await _serviceRecordService.GetAllCarServicesAsync(selectedCar.Id);

        if (categoryId.HasValue)
        {
            ServiceRecords = ServiceRecords
                .Where(sr => sr.ServiceCategoryId == categoryId.Value)
                .ToList();
        }
    }

    public void NavigateToCreateServiceRecord()
    {
        _navigationManager.NavigateTo(UrlConstants.CreateServiceRecord);
    }

    public async Task CreateRecord(AddServiceDto addServiceDto)
    {
        if(addServiceDto.ServiceCategory == null)
        {
            return;
        }

        var selectedCar = await _selectedCarService.GetSelectedCar();

        await _serviceRecordService.AddServiceRecordAsync(
            new ServiceRecord(
                0,
                addServiceDto.Title,
                addServiceDto.ServiceCategory.Id,
                selectedCar.Id,
                addServiceDto.Mileage,
                addServiceDto.Price,
                addServiceDto.Description,
                addServiceDto.DateOfService ?? DateTime.Now,
                null,
                null
            )
        );

        NavigateBackToServicesList();
    }

    public void NavigateBackToServicesList()
    {
        _navigationManager.NavigateTo(UrlConstants.ServiceRecordList);
    }
}