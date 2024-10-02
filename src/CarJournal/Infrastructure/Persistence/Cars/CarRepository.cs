using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;

namespace CarJournal.Infrastructure.Persistence.Cars;

public class CarRepository : ICarRepository
{
    private readonly CarJournalDbContext _dbContext;

    public CarRepository(CarJournalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Car?> GetByIdAsync(int id)
    {
        return await _dbContext.Cars.FindAsync(id);
    }

    public async Task<IEnumerable<Car>> GetAllAsync()
    {
        return await _dbContext.Cars.ToListAsync();
    }

    public async Task<Car> AddAsync(Car car)
    {
        await _dbContext.Cars.AddAsync(car);
        await _dbContext.SaveChangesAsync();

        return car;
    }

    public async Task UpdateAsync(Car car)
    {
        _dbContext.Cars.Update(car);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Car car)
    {
        if (car != null)
        {
            _dbContext.Cars.Remove(car);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Car>> GetByModelAsync(string model)
    {
        return await _dbContext.Cars.Where(c => c.Model == model).ToListAsync();
    }

    public async Task<IEnumerable<Car>> GetCarsByVendorAsync(int vendorId)
    {
        return await _dbContext.Cars.Where(c => c.VendorId == vendorId).ToListAsync();
    }

    public async Task<Car?> GetCarWithDetailsAsync(int id)
    {
        return await _dbContext.Cars
            .Include(c => c.Vendor)
            .Include(c => c.BodyType)
            .Include(c => c.Engine)
            .Include(c => c.Gearbox)
            .Include(c => c.FuelType)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Car>> GetAllCarsWithDetails()
    {
        return await _dbContext.Cars
            .Include(c => c.Vendor)
            .Include(c => c.BodyType)
            .Include(c => c.Engine)
            .Include(c => c.Gearbox)
            .Include(c => c.FuelType)
            .ToListAsync();
    }
}