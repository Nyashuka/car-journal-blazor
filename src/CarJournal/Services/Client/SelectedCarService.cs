
using CarJournal.Domain;
using CarJournal.Services.Authentication.Client;

using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace CarJournal.Services.Client;

public class SelectedCarService : ISelectedCarService
{
    public event Func<int, Task> SelectedCarChangedAsync;
    private readonly ProtectedSessionStorage _sessionStorage;

    public SelectedCarService(ProtectedSessionStorage protectedSessionStorage)
    {
        _sessionStorage = protectedSessionStorage;
    }

    public async Task<string?> GetSelectedCarId()
    {
        var data = await _sessionStorage.GetAsync<string?>(SessionStorageConstants.SelectedCarId);

        return data.Value;
    }

    public async Task SetSelectedCarId(int id)
    {
        await _sessionStorage.SetAsync(SessionStorageConstants.SelectedCarId, id.ToString());

        if (SelectedCarChangedAsync != null)
        {
            foreach (Func<int, Task> handler in SelectedCarChangedAsync.GetInvocationList())
            {
                await handler(id);
            }
        }
    }
}