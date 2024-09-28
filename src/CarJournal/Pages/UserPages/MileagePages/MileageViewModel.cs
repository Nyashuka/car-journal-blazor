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

    private async Task<int> GetSelectedCarId()
    {
        var selectedCar = await _selectedCarService.GetSelectedCarId();

        if(string.IsNullOrEmpty(selectedCar))
        {
            throw new Exception("Car is not selected");
        }

        return Convert.ToInt32(selectedCar);
    }

    public async Task LoadMileages()
    {
        MileageRecords = (await _mileageService.GetAllAsync(await GetSelectedCarId()))
                                .OrderByDescending(m => m.UpdatedAt).ToList();
    }

    public async Task AddMileage()
    {
        var newMileage = new MileageRecord(0, MileageToAdd,
                        false, await GetSelectedCarId(), null, DateTime.UtcNow);

        await _mileageService.AddMileageRecordAsync(newMileage);

        MileageRecords.Add(newMileage);
    }

}