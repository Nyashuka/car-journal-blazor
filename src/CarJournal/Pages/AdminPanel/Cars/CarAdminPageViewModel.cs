using System.Security.Cryptography.X509Certificates;

using CarJournal.ClientDtos;
using CarJournal.Domain;
using CarJournal.Pages.Enums;
using CarJournal.Services.Cars;

using MudBlazor;

namespace CarJournal.Pages.AdminPanel.Cars;

public class CarAdminPageViewModel
{
    private readonly ICarService _carService;

    public CarComponentsData Components { get; private set; }
    public CreateCarDto CreateDto { get; private set; }

    public MudDataGrid<Car> DataGrid { get; private set; } = new();
    public List<Car> Cars { get; private set; }

    public FormState State = FormState.View;

    public CarAdminPageViewModel(ICarService carService, CarComponentsData carComponentsData)
    {
        _carService = carService;
        Components = carComponentsData;
    }

    public async Task Initialize()
    {
        Cars = (await _carService.GetAllCarsAsync()).ToList();
    }

    public async void OpenCreateMenu()
    {
        State = FormState.Create;

        await Components.LoadData();
    }

    public void CloseCreatingOrEditingMenu()
    {
        State = FormState.View;
    }

    public async Task CreateCar()
    {
        var car = new Car(0, CreateDto.Model, CreateDto.Series,
                            CreateDto.Year, CreateDto.Vendor.Id,
                            CreateDto.BodyType.Id, CreateDto.Engine.Id,
                            CreateDto.Gearbox.Id, CreateDto.FuelType.Id);

        var createdCar = await _carService.CreateCarAsync(car);

        Cars.Add(createdCar);
    }

    public void StartedEditingItem(Car item)
    {
    }

    public void CanceledEditingItem(Car item)
    {
    }

    public void CommittedItemChanges(Car item)
    {
    }

    public async Task SaveItemChanges()
    {
    }

    public Task OnSearch(string text)
    {
        return DataGrid.ReloadServerData();
    }

    public void DeleteRecord(Car record)
    {
        _carService.DeleteCarAsync(record.Id);

        Cars.Remove(record);
    }

    public async Task<IEnumerable<Vendor>> SearchVendor(string value, CancellationToken token)
    {
        await Task.Delay(5, token);

        if (string.IsNullOrEmpty(value))
            return Components.Vendors;

        return Components.Vendors.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task<IEnumerable<Gearbox>> SearchGearbox(string value, CancellationToken token)
    {
        await Task.Delay(5, token);

        if (string.IsNullOrEmpty(value))
            return Components.Gearboxes;

        return Components.Gearboxes.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task<IEnumerable<FuelType>> SearchFuelType(string value, CancellationToken token)
    {
        await Task.Delay(5, token);

        if (string.IsNullOrEmpty(value))
            return Components.FuelTypes;

        return Components.FuelTypes.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task<IEnumerable<BodyType>> SearchBodyType(string value, CancellationToken token)
    {
        await Task.Delay(5, token);

        if (string.IsNullOrEmpty(value))
            return Components.BodyTypes;

        return Components.BodyTypes.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task<IEnumerable<Engine>> SearchEngine(string value, CancellationToken token)
    {
        await Task.Delay(5, token);

        if (string.IsNullOrEmpty(value))
            return Components.Engines;

        return Components.Engines.Where(x => x.Model.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }
}