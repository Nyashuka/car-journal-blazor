using CarJournal.Domain;
using CarJournal.Infrastructure.Persistence.Vendors;
using CarJournal.Services.Cars;
using CarJournal.Services.Vendors;

namespace CarJournal.Pages.UserPages;

public class SearchCarsViewModel
{
    public string Vendor { get; set; } = string.Empty;
    public Vendor? SelectedVendor { get; set; }
    public List<Vendor> Vendors { get; set; }

    public string Series { get; set; } = string.Empty;
    public List<string> AllSeries { get; set; } = new();

    public string Year { get; set; } = string.Empty;
    public List<string> Years { get; set; } = new();

    private readonly ICarService _carService;
    private readonly IAdminVendorService _vendorService;


    public List<Car> Cars = new List<Car>();

    public Car? SelectedCar { get; set; }

    public SearchCarsViewModel(
        ICarService carService,
        IAdminVendorService vendorService
        )
    {
        _carService = carService;
        _vendorService = vendorService;
    }

    public async Task InitializeAsync()
    {
        Cars = (await _carService.GetAllCarsWithDetailsAsync()).ToList();
        Vendors = await _vendorService.GetAllAsync();
    }

    public async Task SelectVendor(Vendor vendor)
    {
        SelectedVendor = vendor;
        Cars = await _carService.SearchCars(SelectedVendor?.Name);

        Year = string.Empty;
        Series = string.Empty;
        
        AllSeries = Cars.Select(c => c.Series).Distinct().ToList();
        Years = Cars.Select(c => c.Year.ToString()).Distinct().ToList();
    }

    public async Task SelectSeries(string series)
    {
        Series = series;

        Cars = await _carService.SearchCars(SelectedVendor?.Name, Series);

        Year = string.Empty;
        Years = Cars.Select(c => c.Year.ToString()).ToList();
    }

    public async Task SelectYear(string year)
    {
        Year = year;

        Cars = await _carService.SearchCars(SelectedVendor?.Name, Series, Convert.ToInt32(Year));
    }

    public async Task<IEnumerable<Vendor>> SearchVendor(string value, CancellationToken token)
    {
        await Task.Delay(5, token);

        if (string.IsNullOrEmpty(value))
            return Vendors;

        return Vendors.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task<IEnumerable<string>> SearchSeries(string value, CancellationToken token)
    {
        await Task.Delay(5, token);

        if (string.IsNullOrEmpty(value))
            return AllSeries;

        return AllSeries.Where(x => x.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task<IEnumerable<string>> SearchYears(string value, CancellationToken token)
    {
        await Task.Delay(5, token);

        if (string.IsNullOrEmpty(value))
            return Years;

        return Years.Where(x => x.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }
}