using CarJournal.Domain;

namespace CarJournal.Infrastructure.Persistence.Gearboxes;

public interface IGearboxRepository
{
    void Add(Gearbox gearbox);
    void Remove(Gearbox gearbox);
    Gearbox? GetById(int id);
    List<Gearbox> GetAll();
    Task Save();
}