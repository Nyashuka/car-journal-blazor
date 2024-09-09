
using CarJournal.Domain;

namespace CarJournal.Infrastructure.Persistence.Gearboxes;

public class GearboxRepository : IGearboxRepository
{
    private readonly CarJournalDbContext _dbContext;

    public GearboxRepository(CarJournalDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public void Add(Gearbox gearbox)
    {
        
    }

    public List<Gearbox> GetAll()
    {
        throw new NotImplementedException();
    }

    public Gearbox? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Remove(Gearbox gearbox)
    {
        throw new NotImplementedException();
    }

    public Task Save()
    {
        throw new NotImplementedException();
    }
}