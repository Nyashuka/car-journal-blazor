using CarJournal.Domain;
using CarJournal.Services.Client;
using CarJournal.Services.Mileages;

namespace CarJournal.Pages.UserPages.MileagePages;

public class MileageViewModel
{
    private readonly IMileageService _mileageService;
    private readonly ISelectedCarService _selectedCarService;

    public List<MileageRecord> MileageRecords { get; private set; } = new List<MileageRecord>();

    public int MileageToAdd { get; set; }

    public MileageViewModel(IMileageService mileageService, ISelectedCarService selectedCarService)
    {
        _mileageService = mileageService;
        _selectedCarService = selectedCarService;
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
    }

    public async Task AddMileage()
    {
        var selectedCar = await _selectedCarService.GetSelectedCar();

        if(selectedCar == null || !selectedCar.HasData)
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

        MileageRecords.Add(newMileage);
    }

}