using CarJournal.Domain;
using CarJournal.Services.Cars;

namespace CarJournal.Pages.UserPages;

public class SearchCarsViewModel
{
    public string Vendor { get; set; } = string.Empty;
    public Vendor? SelectedVendor { get; set; }
    public string Model { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;

    private readonly ICarService _carService;

    public List<Car> Cars = new List<Car>();

    public Car? SelectedCar { get; set; }

    public SearchCarsViewModel(ICarService carService)
    {
        _carService = carService;
    }

    public async Task InitializeAsync()
    {
        Cars = (await _carService.GetAllCarsWithDetailsAsync()).ToList();
    }

    public async Task OnSelectedVendor()
    {
        Cars = await _carService.SearchCars(SelectedVendor?.Name);
    }
}