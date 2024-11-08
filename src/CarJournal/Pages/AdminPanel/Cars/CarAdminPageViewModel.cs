using CarJournal.ClientDtos;
using CarJournal.Domain;
using CarJournal.Pages.Enums;
using CarJournal.Services.Cars;

using Microsoft.AspNetCore.Components;

using MudBlazor;

namespace CarJournal.Pages.AdminPanel.Cars;

public class CarAdminPageViewModel
{
    private readonly ICarService _carService;

    public CarComponentsData Components { get; private set; }
    public CreateCarDto CreateDto { get; private set; } = new();

    public MudDataGrid<Car> DataGrid { get; private set; } = new();
    public List<Car> Cars { get; private set; } = new List<Car>();

    public FormState State = FormState.View;

    private readonly NavigationManager _navigationManager;

    public CarAdminPageViewModel(ICarService carService, CarComponentsData carComponentsData, NavigationManager navigationManager)
    {
        _carService = carService;
        Components = carComponentsData;
        _navigationManager = navigationManager;
    }

    public async Task Initialize()
    {
        Cars = (await _carService.GetAllCarsWithDetailsAsync()).ToList();
    }

    public async Task OpenCreateMenu()
    {
        State = FormState.Create;

        await Components.LoadData();
    }

    public async Task EditItem(Car item)
    {
        CreateDto = new CreateCarDto()
        {
            Id = item.Id,
            Vendor = item.Vendor,
            Series = item.Series,
            Model = item.Model,
            Year = item.Year,
            BodyType = item.BodyType,
            Engine = item.Engine,
            FuelType = item.FuelType,
            Gearbox = item.Gearbox,
            DocumentationUrl = item.DocumentationUrl == null ? "" : item.DocumentationUrl
        };

        await Components.LoadData();
    }

    public void CloseCreatingOrEditingMenu()
    {
        State = FormState.View;
    }

    public async Task CreateCar()
    {
        if(CreateDto.Vendor == null || 
            CreateDto.BodyType == null ||
            CreateDto.Engine == null ||
            CreateDto.Gearbox == null ||
            CreateDto.FuelType == null)
        {
            throw new Exception("Fields for creating car can't be null!");
        }

        var car = new Car(0, CreateDto.Model, CreateDto.Series,
                            CreateDto.Year, CreateDto.Vendor.Id,
                            CreateDto.BodyType.Id, CreateDto.Engine.Id,
                            CreateDto.Gearbox.Id, CreateDto.FuelType.Id, CreateDto.DocumentationUrl);

        var createdCar = await _carService.CreateCarAsync(car);

        Cars.Add(createdCar);

        _navigationManager.NavigateTo(_navigationManager.Uri, true);
    }

    public async Task SaveItemChanges()
    {
        await _carService.UpdateCarAsync(CreateDto.Id, CreateDto);
        _navigationManager.NavigateTo(_navigationManager.Uri, true);
    }

    public Task OnSearch(string text)
    {
        return DataGrid.ReloadServerData();
    }

    public async Task DeleteRecord(Car record)
    {
        await _carService.DeleteCarAsync(record.Id);

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