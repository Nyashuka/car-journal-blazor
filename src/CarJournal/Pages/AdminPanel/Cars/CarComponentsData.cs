using CarJournal.Domain;
using CarJournal.Services;
using CarJournal.Services.Engines;
using CarJournal.Services.Vendors;

namespace CarJournal.Pages.AdminPanel.Cars;

public class CarComponentsData
{
    public List<Vendor> Vendors { get; private set; } = new();
    public List<Gearbox> Gearboxes { get; private set; } = new();
    public List<FuelType> FuelTypes { get; private set; } = new();
    public List<BodyType> BodyTypes { get; private set; } = new();
    public List<Engine> Engines { get; set; } = new();

    private readonly IAdminVendorService _vendorService;
    private readonly IGenericService<Gearbox> _gearboxService;
    private readonly IGenericService<FuelType> _fuelTypeService;
    private readonly IGenericService<BodyType> _bodyTypeService;
    private readonly IGenericService<Engine> _engineService;

    public CarComponentsData(IAdminVendorService vendorService,
                             IGenericService<Gearbox> gearboxService,
                             IGenericService<FuelType> fuelTypeService,
                             IGenericService<BodyType> bodyTypeService,
                             IGenericService<Engine> engineService
                             )
    {
        _vendorService = vendorService;
        _gearboxService = gearboxService;
        _fuelTypeService = fuelTypeService;
        _bodyTypeService = bodyTypeService;
        _engineService = engineService;
    }

    public async Task LoadData()
    {
        Vendors = await _vendorService.GetAllAsync();
        Gearboxes = (await _gearboxService.GetAllAsync()).ToList();
        FuelTypes = (await _fuelTypeService.GetAllAsync()).ToList();
        BodyTypes = (await _bodyTypeService.GetAllAsync()).ToList();
        Engines = (await _engineService.GetAllAsync()).ToList();
    }
}