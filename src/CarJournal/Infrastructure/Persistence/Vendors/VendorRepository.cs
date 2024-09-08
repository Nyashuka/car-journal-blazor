
using CarJournal.Domain;

namespace CarJournal.Infrastructure.Persistence.Vendors;

public class VendorRepository : IVendorRepository
{
    private readonly CarJournalDbContext _dbContext;

    public VendorRepository(CarJournalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Vendor vendor)
    {
        _dbContext.Vendors.Add(vendor);
        await _dbContext.SaveChangesAsync();
    }

    public List<Vendor> GetAll()
    {
        return _dbContext.Vendors.ToList();
    }

    public Vendor? GetById(int id)
    {
        return _dbContext.Vendors.SingleOrDefault(v => v.Id == id);
    }

    public void Remove(Vendor vendor)
    {
        _dbContext.Set<Vendor>().Remove(vendor);
    }

    public async Task Save()
    {
        await _dbContext.SaveChangesAsync();
    }
}