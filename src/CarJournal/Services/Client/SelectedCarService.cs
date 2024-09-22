
using CarJournal.Domain;
using CarJournal.Services.Authentication.Client;

using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace CarJournal.Services.Client;

public class SelectedCarService : ISelectedCarService
{
    public event Action<int> UserCarChanged;
    private readonly ProtectedSessionStorage _sessionStorage;

    public SelectedCarService(ProtectedSessionStorage protectedSessionStorage)
    {
        _sessionStorage = protectedSessionStorage;
    }

    public async Task<int?> GetSelectedCarId()
    {
        var data = await _sessionStorage.GetAsync<int?>(SessionStorageConstants.SelectedCarId);

        return data.Value;
    }

    public async Task SetSelectedCarId(int id)
    {
        await _sessionStorage.SetAsync(SessionStorageConstants.SelectedCarId, id);

        UserCarChanged?.Invoke(id);
    }
}