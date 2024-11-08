using CarJournal.ClientDtos;
using CarJournal.Domain;

namespace CarJournal.Services.Cars;

public interface ICarService
{
    Task<Car> CreateCarAsync(Car car);
    Task<IEnumerable<Car>> GetAllCarsAsync();
    Task<IEnumerable<Car>> GetAllCarsWithDetailsAsync();
    Task<Car?> GetCarByIdAsync(int id);
    Task UpdateCarAsync(int id, CreateCarDto updateCarDto);
    Task DeleteCarAsync(int id);
    Task<List<Car>> SearchCars(string? vendor = null, string? series = null, int? year = null);
}