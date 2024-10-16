using CarJournal.ClientDtos;
using CarJournal.Services.Client;
using CarJournal.Services.Mileages;
using CarJournal.Services.Trackings;
using CarJournal.Services.UserCars;

using Microsoft.AspNetCore.Components;

namespace CarJournal.Pages.UserPages.TrackingPages;

public class CreateTrackingViewModel
{
    private readonly ITrackingService _trackingService;
    private readonly NavigationManager _navigationManager;
    private readonly ISelectedCarService _selectedCarService;
    private readonly IUserCarsService _userCarsService;
    private readonly IMileageService _mileageService;

    public CreateTrackingDto CreateTrackingDto { get; set; }

    public bool HasTodayMileageRecord { get; private set; } = false;

    public CreateTrackingViewModel(
        ITrackingService trackingService,
        NavigationManager navigationManager,
        ISelectedCarService selectedCarService,
        IUserCarsService userCarsService,
        IMileageService mileageService)
    {
        _trackingService = trackingService;
        _navigationManager = navigationManager;
        CreateTrackingDto = new CreateTrackingDto();
        _selectedCarService = selectedCarService;
        _userCarsService = userCarsService;
        _mileageService = mileageService;
    }

    public async Task InitializeAsync()
    {
        HasTodayMileageRecord = false;

        var selectedCar = await _selectedCarService.GetSelectedCar();

        if(selectedCar == null || !selectedCar.HasData)
        {
            return;
        }

        var mileage = await _mileageService.GetLastMileage(selectedCar.Id);

        if(mileage == null)
        {
            return;
        }

        if(mileage.UpdatedAt.Date == DateTime.Today)
        {
            HasTodayMileageRecord = true;
        }
    }

    public void NavigateBackToTrackingList()
    {
        _navigationManager.NavigateTo("/trackings");
    }

    public void CreateRecord()
    {

    }
}