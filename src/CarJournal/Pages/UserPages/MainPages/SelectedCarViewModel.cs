using CarJournal.Domain;
using CarJournal.Services.Authentication;
using CarJournal.Services.Cars;
using CarJournal.Services.Client;
using CarJournal.Services.UserCars;

using Microsoft.AspNetCore.Components;

namespace CarJournal.Pages.UserPages.MainPages;

public class SelectedCarViewModel
{
    private readonly IUserCarsService _userCarsService;
    private readonly IClientAuthenticationService _authenticationService;
    private readonly ISelectedCarService _selectedCarService;
    private readonly NavigationManager _navigationManager;

    public UserCar? SelectedCar { get; set; }
    public List<UserCar> UserCars { get; set; } = new();
    public string ErrorMessage { get; private set; }

    public SelectedCarViewModel(IUserCarsService userCarService,
                             IClientAuthenticationService authenticationService,
                             ISelectedCarService selectedCarService,
                             NavigationManager navigationManager)
    {
        _userCarsService = userCarService;
        _authenticationService = authenticationService;
        _selectedCarService = selectedCarService;
        _navigationManager = navigationManager;
    }

    public async Task LoadUserCarsAsync()
    {
        var userIdString = await _authenticationService.GetUserIdAsync();

        if(userIdString == null)
        {
            throw new Exception("No authorized (load user cars)");
        }

        UserCars = await _userCarsService.GetAllAsync(Convert.ToInt32(userIdString));

        var selectedCar = await _selectedCarService.GetSelectedCar();

        if(selectedCar != null && selectedCar.HasData)
        {
            var car = UserCars.FirstOrDefault(uc => uc.Id == Convert.ToInt32(selectedCar.Id));
            await OnSelectedCarChanged(car);
        }
        else
        {
            if(UserCars.Count < 1)
            {
                ErrorMessage = "You may add car in garage!";
                return;
            }
                // throw new Exception("\n\n\nNO CARS, NEED HANDLE\n\n\n");

            await OnSelectedCarChanged(UserCars.FirstOrDefault());
        }
    }

    public async Task OnSelectedCarChanged(UserCar? userCar)
    {
        if(userCar == null)
            return;

        SelectedCar = userCar;

        await _selectedCarService.SetSelectedCar(userCar.Id, userCar.Name);
    }

    public async Task<IEnumerable<UserCar>> SearchCar(string value, CancellationToken token)
    {
        await Task.Delay(5, token);

        if (string.IsNullOrEmpty(value))
            return UserCars;

        return UserCars.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }
}