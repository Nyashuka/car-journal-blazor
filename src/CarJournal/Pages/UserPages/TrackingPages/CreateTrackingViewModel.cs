using CarJournal.ClientDtos;
using CarJournal.Services.Trackings;

using Microsoft.AspNetCore.Components;

namespace CarJournal.Pages.UserPages.TrackingPages;

public class CreateTrackingViewModel
{
    private readonly ITrackingService _trackingService;
    private readonly NavigationManager _navigationManager;

    public CreateTrackingDto CreateTrackingDto { get; set; }

    public CreateTrackingViewModel(ITrackingService trackingService, NavigationManager navigationManager)
    {
        _trackingService = trackingService;
        _navigationManager = navigationManager;
        CreateTrackingDto = new CreateTrackingDto();
    }

    public void NavigateBackToTrackingList()
    {

    }

    public void CreateRecord()
    {

    }
}