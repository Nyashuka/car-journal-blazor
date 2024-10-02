using CarJournal.Domain;

namespace CarJournal.Services.Engines;

public interface IEngineService
{
    Task<List<Engine>> GetAllAsync();
    Task Add(string model, float size);
    Task Remove(int id);
    Task Update(int id, string model, float size);
}