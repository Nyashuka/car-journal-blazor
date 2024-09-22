using CarJournal.Domain;

namespace CarJournal.Services.Client;

public interface ISelectedCarService
{
    Task SetSelectedCarId(int id);
    Task<int?> GetSelectedCarId();

    event Action<int> UserCarChanged;  
}