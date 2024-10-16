using System.Security.Cryptography;

using CarJournal.Services.Authentication.Client;

using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace CarJournal.Services.Client;

public class SelectedCarService : ISelectedCarService
{
    public event Func<SelectedCarData, Task> SelectedCarChangedAsync;
    private readonly ProtectedSessionStorage _sessionStorage;
    private SelectedCarData? _selectedCarData;

    public SelectedCarService(ProtectedSessionStorage sessionStorage)
    {
        _sessionStorage = sessionStorage;
    }


    private async Task<SelectedCarData?> TryGetSelectedCar()
    {
        try
        {
            var data = await _sessionStorage.GetAsync<SelectedCarData?>(SessionStorageConstants.SelectedCar);

            return data.Value;
        }
        catch (CryptographicException)
        {
            await _sessionStorage.DeleteAsync(SessionStorageConstants.SelectedCar);

            var car = new SelectedCarData("Authorization error, please relogin your session");
            await _sessionStorage.SetAsync(SessionStorageConstants.SelectedCar, car
                    );

            return car;
        }
    }

    public async Task<SelectedCarData> GetSelectedCar()
    {
        if(_selectedCarData != null)
        {
            return _selectedCarData;
        }

        var selectedCar = await TryGetSelectedCar();

        if(selectedCar == null)
        {
            return new SelectedCarData("You may add car in Garage");
        }

        return selectedCar;
    }

    public async Task SetSelectedCar(int id, string name)
    {
        var selectedCar = new SelectedCarData(id, name, true);
        await _sessionStorage.SetAsync(SessionStorageConstants.SelectedCar, selectedCar);

        _selectedCarData = selectedCar;

        await InvokeAllAboutSelectingCar(selectedCar);
    }

    private async Task InvokeAllAboutSelectingCar(SelectedCarData selectedCar)
    {
        if (SelectedCarChangedAsync != null)
        {
            foreach (Func<SelectedCarData, Task> handler in SelectedCarChangedAsync.GetInvocationList())
            {
                await handler(selectedCar);
            }
        }
    }
}