using CarJournal.ClientDtos;
using CarJournal.Domain;
using CarJournal.Services.Client;
using CarJournal.Services.Mileages;
using CarJournal.Services.ServiceRecords;
using CarJournal.Services.Trackings;

using Hangfire.Storage.Monitoring;

using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using MudBlazor;

namespace CarJournal.Pages.UserPages.TrackingPages;

public class TrackingListViewModel
{
    private readonly ITrackingService _trackingService;
    private readonly ISelectedCarService _selectedCarService;
    private readonly NavigationManager _navigationManager;
    private readonly IMileageService _mileageService;
    private readonly IServiceRecordService _serviceRecordService;

    public List<Tracking> Trackings { get; private set; }

    public TrackingListViewModel(
        ITrackingService trackingService,
        ISelectedCarService selectedCarService,
        NavigationManager navigationManager,
        IMileageService mileageService,
        IServiceRecordService serviceRecordService)
    {
        _trackingService = trackingService;
        _selectedCarService = selectedCarService;
        Trackings = new List<Tracking>();
        _navigationManager = navigationManager;
        _mileageService = mileageService;
        _serviceRecordService = serviceRecordService;
    }

    public async Task<bool> CanReset()
    {
        var selectedCar = await _selectedCarService.GetSelectedCar();
        var lastMileage = await _mileageService.GetLastMileage(selectedCar.Id);

        return lastMileage.UpdatedAt.Date == DateTime.Today.Date;
    }

    public async Task Initialize()
    {
        var selectedCar = await _selectedCarService.GetSelectedCar();

        if(selectedCar == null || !selectedCar.HasData)
            return;

        Trackings = await _trackingService.GetAllTrackingsByCarIdAsync(selectedCar.Id, null);
    }

    public async Task DeleteRecord(int id)
    {
        await _trackingService.DeleteTrackingAsync(id);
        _navigationManager.NavigateTo(_navigationManager.Uri, true);
    }

    public void NavigateToCreateTrackingPage()
    {
        _navigationManager.NavigateTo("/trackings/create");
    }

    public async Task ResetTracking(int trackingId)
    {
        if(await CanReset())
        {
            await _trackingService.ResetTracking(trackingId);
        }
    }

    public async Task AddService(AddServiceDto model)
    {
        var service = new ServiceRecord(
            0,
            model.Title,
            model.ServiceCategory == null ? 0 : model.ServiceCategory.Id,
            model.UserCarId,
            model.Mileage,
            model.Price,
            model.Description,
            model.DateOfService ?? DateTime.UtcNow,
            null, null
        );

        await _serviceRecordService.AddServiceRecordAsync(service);
    }
}