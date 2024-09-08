using CarJournal.Domain;

namespace CarJournal.Infrastructure.Persistence.Vendors;

public interface IVendorRepository
{
    Task Add(Vendor vendor);
    Vendor? GetById(int id);
    List<Vendor> GetAll();
    void Remove(Vendor vendor);
    Task Save();
}