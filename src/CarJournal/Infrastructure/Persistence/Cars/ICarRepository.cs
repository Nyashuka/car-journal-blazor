using CarJournal.Domain;

namespace CarJournal.Infrastructure.Persistence.Cars;

public interface ICarRepository
{
    Task<Car?> GetByIdAsync(int id);
    Task<IEnumerable<Car>> GetAllAsync();
    Task<IEnumerable<Car>> GetAllCarsWithDetails();
    Task<Car> AddAsync(Car car);
    Task UpdateAsync(Car car);
    Task DeleteAsync(Car car);

    Task<IEnumerable<Car>> GetByModelAsync(string model);
    Task<IEnumerable<Car>> GetCarsByVendorAsync(int vendorId);
    Task<Car?> GetCarWithDetailsAsync(int id);
}