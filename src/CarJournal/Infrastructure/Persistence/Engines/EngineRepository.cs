
using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;

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

    public async Task<List<Engine>> GetAllAsync()
    {
        return await _dbContext.Engines.ToListAsync();
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
        _dbContext.SaveChanges();
    }
}