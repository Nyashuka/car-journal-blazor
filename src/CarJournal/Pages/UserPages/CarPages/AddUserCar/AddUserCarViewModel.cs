using CarJournal.ClientDtos;
using CarJournal.Domain;
using CarJournal.Services.Authentication;
using CarJournal.Services.UserCars;

using Microsoft.AspNetCore.Components;

namespace CarJournal.Pages.UserPages.CarPages.AddUserCar;

public class AddUserCarViewModel : ISearchCarComponents
{
    private readonly IUserCarsService _userCarsService;
    private readonly IClientAuthenticationService _authenticationService;
    private readonly NavigationManager _navigationManager;

    public AddUserCarDto AddUserCarDto { get; private set; } = new AddUserCarDto();
    public List<Car> SearchedCars { get; set; } = new List<Car>();

    public string BindedCarText { get; private set; } = string.Empty;

    public AddUserCarViewModel(
        IUserCarsService userCarsService,
        IClientAuthenticationService authenticationService,
        NavigationManager navigationManager)
    {
        _userCarsService = userCarsService;
        _authenticationService = authenticationService;
        _navigationManager = navigationManager;
    }

    public async Task AddCar()
    {
        var userId = await _authenticationService.GetUserIdAsync();

        if(userId == null)
        {
            throw new Exception ("not authorized");
        }

        var car = new UserCar(
            0,
            AddUserCarDto.Name,
            AddUserCarDto.StartMileage,
            AddUserCarDto.StartMileage,
            0,
            Convert.ToInt32(userId), null,
            AddUserCarDto.Car?.Id,
            null,
            DateTime.UtcNow
        );

       await _userCarsService.AddUserCarAsync(car);
       NavigateToGarage();
    }

    public void NavigateToGarage()
    {
        _navigationManager.NavigateTo("/garage", true);
    }

    public Task<IEnumerable<BodyType>> SearchBodyType(string value, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Engine>> SearchEngine(string value, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<FuelType>> SearchFuelType(string value, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Gearbox>> SearchGearbox(string value, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Vendor>> SearchVendor(string value, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}