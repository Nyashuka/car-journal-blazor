using System.Security.Cryptography;

using CarJournal.Services.Authentication.Client;

using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace CarJournal.Services.Client;

public class SelectedCarService : ISelectedCarService
{
    public event Func<SelectedCarData, Task> SelectedCarChangedAsync;
    private readonly ProtectedSessionStorage _sessionStorage;

    public SelectedCarService(ProtectedSessionStorage sessionStorage)
    {
        _sessionStorage = sessionStorage;
    }

    // private async Task<string?> TryGetSelectedCarId()
    // {
    //     try
    //     {
    //         var data = await _sessionStorage.GetAsync<string?>(SessionStorageConstants.SelectedCarId);

    //         return data.Value;
    //     }
    //     catch (CryptographicException)
    //     {
    //         await _sessionStorage.DeleteAsync(SessionStorageConstants.SelectedCarId);
    //         return null;
    //     }
    // }

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
        var selectedCar = await TryGetSelectedCar();

        if(selectedCar == null)
        {
            return new SelectedCarData("You may add car in Garage");
        }

        return selectedCar;
    }

    // private async Task<string?> GetSelectedCarName()
    // {
    //     ProtectedBrowserStorageResult<string?> data; try
    //     {
    //         data = await _sessionStorage.GetAsync<string?>(SessionStorageConstants.SelectedCarName);

    //         return data.Value;
    //     }
    //     catch (CryptographicException)
    //     {
    //         await _sessionStorage.DeleteAsync(SessionStorageConstants.SelectedCarName);
    //         return null;
    //     }
    // }

    public async Task SetSelectedCar(int id, string name)
    {
        // await _sessionStorage.SetAsync(SessionStorageConstants.SelectedCarId, id.ToString());
        // await _sessionStorage.SetAsync(SessionStorageConstants.SelectedCarName, name);
        var selectedCar = new SelectedCarData(id, name, true);
        await _sessionStorage.SetAsync(SessionStorageConstants.SelectedCar, selectedCar);

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