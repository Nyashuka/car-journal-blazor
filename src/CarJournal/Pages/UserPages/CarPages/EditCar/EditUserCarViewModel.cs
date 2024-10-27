using AutoMapper;

using CarJournal.ClientDtos;
using CarJournal.Domain;
using CarJournal.Services.Authentication;
using CarJournal.Services.UserCars;

using Microsoft.AspNetCore.Components;

namespace CarJournal.Pages.UserPages.CarPages.EditCar;

public class EditUserCarViewModel : ISearchCarComponents
{
    private readonly IUserCarsService _userCarsService;
    private readonly IClientAuthenticationService _authenticationService;
    private readonly IMapper _mapper;
    private readonly NavigationManager _navigationManager;

    public UpdateUserCarDto UserCarDto { get; private set; } = new UpdateUserCarDto();
    public List<Car> SearchedCars { get; set; } = new List<Car>();

    public string BindedCarText { get; private set; } = string.Empty;

    public EditUserCarViewModel(
        IUserCarsService userCarsService,
        IClientAuthenticationService authenticationService,
        IMapper mapper,
        NavigationManager navigationManager)
    {
        _userCarsService = userCarsService;
        _authenticationService = authenticationService;
        _mapper = mapper;
        _navigationManager = navigationManager;
    }

    public async Task InitializeAsync(int userCarId)
    {
        var userCar = await _userCarsService.GetByIdAsync(userCarId);
        if(userCar == null)
        {
            return;
        }

        _mapper.Map(userCar, UserCarDto);
    }

    public async Task UpdateCar()
    {
        var userCar = await _userCarsService.GetByIdAsync(UserCarDto.Id);

        if(userCar == null)
        {
            return;
        }

        await _userCarsService.UpdateUserCarAsync(_mapper.Map(UserCarDto, userCar));
        _navigationManager.NavigateTo("/garage");
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