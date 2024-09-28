using CarJournal.Domain;

namespace CarJournal.Services.Client;

public interface ISelectedCarService
{
    Task SetSelectedCarId(int id);
    Task<string?> GetSelectedCarId();

    event Func<int, Task> SelectedCarChangedAsync;
}