using CarJournal.Domain;

namespace CarJournal.Infrastructure.Persistence.Vendors;

public class VendorRepository : IVendorRepository
{
    private readonly CarJournalDbContext _dbContext;

    public VendorRepository(CarJournalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Vendor vendor)
    {
        _dbContext.Vendors.Add(vendor);
        _dbContext.SaveChangesAsync();
    }

    public Vendor? GetById(int id)
    {
        return _dbContext.Vendors.SingleOrDefault(v => v.Id == id);
    }
}