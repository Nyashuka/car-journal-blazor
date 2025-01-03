using CarJournal.Domain;
using CarJournal.Services.AutoMileageCalculator;
using CarJournal.Services.Client;
using CarJournal.Services.Mileages;
using CarJournal.Services.Trackings;
using CarJournal.Services.UserCars;

using Microsoft.AspNetCore.Http.Features;

namespace CarJournal.Pages.UserPages.MileagePages;

public class MileageViewModel
{
    private readonly IMileageService _mileageService;
    private readonly ISelectedCarService _selectedCarService;
    private readonly IUserCarsService _userCarsService;
    private readonly ITrackingService _trackingService;

    public List<MileageRecord> MileageRecords { get; private set; } = new List<MileageRecord>();
    public MileageRecord LastMileage { get; private set; } 

    public int MileageToAdd { get; set; }

    public MileageViewModel(IMileageService mileageService, ISelectedCarService selectedCarService, IUserCarsService userCarsService, ITrackingService trackingService)
    {
        _mileageService = mileageService;
        _selectedCarService = selectedCarService;
        _userCarsService = userCarsService;
        _trackingService = trackingService;
    }

    public async Task LoadMileages()
    {
        var selectedCar = await _selectedCarService.GetSelectedCar();

        if(selectedCar == null || !selectedCar.HasData)
        {
            return;
            //throw new Exception("\n\n\nNEED HANDLE\n\n\n");
        }

        MileageRecords = (await _mileageService.GetAllAsync(selectedCar.Id))
                                .OrderByDescending(m => m.UpdatedAt)
                                .ToList();

        if(MileageRecords.Count > 0)
        {
            LastMileage = MileageRecords.First();
            MileageToAdd = LastMileage.Mileage;
        }
    }

    public async Task UpdateMileage()
    {
        var selectedCar = await _selectedCarService.GetSelectedCar();

        if (selectedCar == null || !selectedCar.HasData)
        {
            return;
        }

        var newMileage = new MileageRecord(
            0,
            MileageToAdd,
            false,
            selectedCar.Id,
            null,
            DateTime.UtcNow
        );

        await _mileageService.AddMileageRecordAsync(newMileage);

        await LoadMileages();
    }

    public async Task DeleteMileage(int mileageId)
    {
        await _mileageService.DeleteMileageRecordAsync(mileageId);

        await LoadMileages();
    }
}