using CarJournal.Domain;

using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace CarJournal.Services.Client;

public interface ISelectedCarService
{
    Task SetSelectedCar(int id, string name);
    Task<SelectedCarData> GetSelectedCar();

    event Func<SelectedCarData, Task> SelectedCarChangedAsync;
}