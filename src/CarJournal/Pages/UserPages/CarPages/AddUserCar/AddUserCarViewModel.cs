using CarJournal.ClientDtos;
using CarJournal.Domain;
using CarJournal.Services.Authentication;
using CarJournal.Services.UserCars;

namespace CarJournal.Pages.UserPages;

public class AddUserCarViewModel : ISearchCarComponents
{
    private readonly IUserCarsService _userCarsService;
    private readonly IClientAuthenticationService _authenticationService;
    public AddUserCarDto AddUserCarDto { get; private set; } = new AddUserCarDto();
    public List<Car> SearchedCars { get; set; } = new List<Car>();

    public string BindedCarText { get; private set; }

    public AddUserCarViewModel(
        IUserCarsService userCarsService,
        IClientAuthenticationService authenticationService)
    {
        _userCarsService = userCarsService;
        _authenticationService = authenticationService;
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