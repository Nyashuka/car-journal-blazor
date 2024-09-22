using CarJournal.Domain;
using CarJournal.Services.Authentication;
using CarJournal.Services.UserCars;

namespace CarJournal.Pages.UserPages.CarPages.Garage;

public class UserGarageViewModel
{
    private readonly IUserCarsService _userCarsService;
    private readonly IClientAuthenticationService _authenticationService;
    public List<UserCar> UserCars { get; private set; } = new List<UserCar>();
    public string Vendor { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;

    public UserGarageViewModel(IUserCarsService userCarsService,
                               IClientAuthenticationService clientAuthenticationService)
    {
        _userCarsService = userCarsService;
        _authenticationService = clientAuthenticationService;
    }

    public async Task LoadCars()
    {
        var userIdString = await _authenticationService.GetUserIdAsync();

        if(userIdString == null)
        {
            throw new Exception("No authorized (load user cars)");
        }

        UserCars = await _userCarsService.GetAllAsync(Convert.ToInt32(userIdString));
    }
}