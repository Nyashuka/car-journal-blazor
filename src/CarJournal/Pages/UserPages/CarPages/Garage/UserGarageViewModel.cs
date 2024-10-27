using CarJournal.Domain;
using CarJournal.Services.Authentication;
using CarJournal.Services.UserCars;

using Microsoft.AspNetCore.Components;

namespace CarJournal.Pages.UserPages.CarPages.Garage;

public class UserGarageViewModel
{
    private readonly IUserCarsService _userCarsService;
    private readonly IClientAuthenticationService _authenticationService;
    private readonly NavigationManager _navigationManager;

    public List<UserCar> UserCars { get; private set; } = new List<UserCar>();
    public string Vendor { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;

    public UserGarageViewModel(IUserCarsService userCarsService,
                               IClientAuthenticationService clientAuthenticationService,
                               NavigationManager navigationManager)
    {
        _userCarsService = userCarsService;
        _authenticationService = clientAuthenticationService;
        _navigationManager = navigationManager;
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

    public async Task DeleteRecord(int id)
    {
        await _userCarsService.DeleteUserCarAsync(id);

        _navigationManager.NavigateTo(_navigationManager.Uri, true);
    }
}