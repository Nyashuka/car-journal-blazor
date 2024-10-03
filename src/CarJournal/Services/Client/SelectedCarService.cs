using System.Security.Cryptography;

using CarJournal.Services.Authentication.Client;

using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace CarJournal.Services.Client;

public class SelectedCarService : ISelectedCarService
{
    public event Func<int, string, Task> SelectedCarChangedAsync;
    private readonly ProtectedSessionStorage _sessionStorage;

    public SelectedCarService(ProtectedSessionStorage sessionStorage)
    {
        _sessionStorage = sessionStorage;
    }

    public async Task<string?> GetSelectedCarId()
    {
        try
        {
            var data = await _sessionStorage.GetAsync<string?>(SessionStorageConstants.SelectedCarId);

            return data.Value;
        }
        catch (CryptographicException)
        {
            await _sessionStorage.DeleteAsync(SessionStorageConstants.SelectedCarId);
            return null;
        }
    }

    public async Task<string?> GetSelectedCarName()
    {
        ProtectedBrowserStorageResult<string?> data;
        try
        {
            data = await _sessionStorage.GetAsync<string?>(SessionStorageConstants.SelectedCarName);

            return data.Value;
        }
        catch (CryptographicException)
        {
            await _sessionStorage.DeleteAsync(SessionStorageConstants.SelectedCarName);
            return null;
        }
    }

    public async Task SetSelectedCar(int id, string name)
    {
        await _sessionStorage.SetAsync(SessionStorageConstants.SelectedCarId, id.ToString());
        await _sessionStorage.SetAsync(SessionStorageConstants.SelectedCarName, name);

        if (SelectedCarChangedAsync != null)
        {
            foreach (Func<int, string, Task> handler in SelectedCarChangedAsync.GetInvocationList())
            {
                await handler(id, name);
            }
        }
    }
}