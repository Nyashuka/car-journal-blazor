using CarJournal.Domain;

using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace CarJournal.Services.Client;

public interface ISelectedCarService
{
    Task SetSelectedCar(int id, string name);
    Task<string?> GetSelectedCarId();
    Task<string?> GetSelectedCarName();

    event Func<int, string, Task> SelectedCarChangedAsync;
}