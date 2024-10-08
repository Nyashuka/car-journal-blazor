using CarJournal.Domain;
using CarJournal.Services.Client;
using CarJournal.Services.ServiceRecords;

using Microsoft.AspNetCore.Components;

namespace CarJournal.Pages.UserPages.ServicesPages;

public class ServiceRecordsListViewModel
{
    private readonly IServiceRecordService _serviceRecordService;
    private readonly ISelectedCarService _selectedCarService;
    private readonly NavigationManager _navigationManager;

    public List<ServiceRecord> ServiceRecords { get; private set; }

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

    public async Task InitializeAsync()
    {
        var selectedCar = await _selectedCarService.GetSelectedCar();

        ServiceRecords = await _serviceRecordService.GetAllCarServicesAsync(selectedCar.Id);
    }

    public void NavigateToCreateServiceRecord()
    {
        _navigationManager.NavigateTo(UrlConstants.CreateServiceRecord);
    }
}