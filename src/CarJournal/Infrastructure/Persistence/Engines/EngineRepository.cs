
using CarJournal.Domain;

namespace CarJournal.Infrastructure.Persistence.Engines;

public class EngineRepository : IEngineRepository
{
    private readonly CarJournalDbContext _dbContext;

    public EngineRepository(CarJournalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Engine engine)
    {
        _dbContext.Add(engine);
    }

    public List<Engine> GetAll()
    {
        return _dbContext.Engines.ToList();
    }

    public Engine? GetById(int id)
    {
        return _dbContext.Set<Engine>().SingleOrDefault(e => e.Id == id);
    }

    public void Remove(Engine engine)
    {
        _dbContext.Engines.Remove(engine);
    }

    public async Task Save()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Update(Engine engine)
    {
        _dbContext.Set<Engine>().Update(engine);
    }
}