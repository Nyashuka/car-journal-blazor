using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;

namespace CarJournal.Infrastructure.Persistence.Cars;

public class CarRepository : ICarRepository
{
    private readonly CarJournalDbContext _dbContext;
    private readonly DbSet<Car> _dbSet;

    public CarRepository(CarJournalDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<Car>();
    }

    // Отримати Car за ID
    public async Task<Car?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<Car>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task AddAsync(Car car)
    {
        await _dbSet.AddAsync(car);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Car car)
    {
        _dbSet.Update(car);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Car car)
    {
        if (car != null)
        {
            _dbSet.Remove(car);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Car>> GetByModelAsync(string model)
    {
        return await _dbSet.Where(c => c.Model == model).ToListAsync();
    }

    public async Task<IEnumerable<Car>> GetCarsByVendorAsync(int vendorId)
    {
        return await _dbSet.Where(c => c.VendorId == vendorId).ToListAsync();
    }

    public async Task<Car?> GetCarWithDetailsAsync(int id)
    {
        return await _dbSet
            .Include(c => c.Vendor)
            .Include(c => c.BodyType)
            .Include(c => c.Engine)
            .Include(c => c.Gearbox)
            .Include(c => c.FuelType)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}