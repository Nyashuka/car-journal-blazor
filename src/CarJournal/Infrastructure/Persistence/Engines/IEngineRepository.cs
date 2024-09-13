using CarJournal.Domain;
using CarJournal.Infrastructure.Authentication;

namespace CarJournal.Infrastructure.Persistence.Engines;

public interface IEngineRepository
{
    void Add(Engine engine);
    void Remove(Engine engine);
    Task<List<Engine>> GetAllAsync();
    Engine? GetById(int id);
    void Update(Engine engine);
    Task Save();
}
