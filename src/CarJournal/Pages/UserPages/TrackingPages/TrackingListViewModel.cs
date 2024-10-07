using System.Net.Http.Headers;

using CarJournal.Services.Client;
using CarJournal.Services.Trackings;

namespace CarJournal.Pages.UserPages.TrackingPages;

public class TrackingListViewModel
{
    private readonly ITrackingService _trackingService;
    private readonly ISelectedCarService _selectedCarService;

    public TrackingListViewModel(ITrackingService trackingService, ISelectedCarService selectedCarService)
    {
        _trackingService = trackingService;
        _selectedCarService = selectedCarService;
    }

    
}