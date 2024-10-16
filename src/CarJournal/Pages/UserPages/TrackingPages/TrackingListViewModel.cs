using CarJournal.Domain;
using CarJournal.Services.Client;
using CarJournal.Services.Trackings;

using Microsoft.AspNetCore.Components;

namespace CarJournal.Pages.UserPages.TrackingPages;

public class TrackingListViewModel
{
    private readonly ITrackingService _trackingService;
    private readonly ISelectedCarService _selectedCarService;
    private readonly NavigationManager _navigationManager;

    public List<Tracking> Trackings { get; private set; }

    public TrackingListViewModel(
        ITrackingService trackingService,
        ISelectedCarService selectedCarService,
        NavigationManager navigationManager)
    {
        _trackingService = trackingService;
        _selectedCarService = selectedCarService;
        Trackings = new List<Tracking>();
        _navigationManager = navigationManager;
    }

    public async Task Initialize()
    {
        var selectedCar = await _selectedCarService.GetSelectedCar();

        if(selectedCar == null || !selectedCar.HasData)
            return;

        Trackings = await _trackingService.GetAllTrackingsByCarIdAsync(selectedCar.Id);
    }

    public void NavigateToCreateTrackingPage()
    {
        _navigationManager.NavigateTo("/trackings/create");
    }
}