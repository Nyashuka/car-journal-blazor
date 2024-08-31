using CarJournal.Domain;

namespace CarJournal.Infrastructure.Persistence.Vendors;

public interface IVendorRepository
{
    void Add(Vendor vendor);
    Vendor? GetById(int id);
}