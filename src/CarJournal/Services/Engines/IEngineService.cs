using CarJournal.Domain;

namespace CarJournal.Services.Engines;

public interface IEngineService
{
    List<Engine> GetAll();
    Task Add(string model, float size);
    Task Remove(int id);
    Task Update(int id, string model, float size);
}