using CarJournal.Domain;
using CarJournal.Services.DTOs;

namespace CarJournal.Services.Cars;

public interface ICarService
{
    Task<Car> CreateCarAsync(Car car);
    Task<IEnumerable<Car>> GetAllCarsAsync();
    Task<IEnumerable<Car>> GetAllCarsWithDetailsAsync();
    Task<Car?> GetCarByIdAsync(int id);
    Task UpdateCarAsync(int id, UpdateCarDto updateCarDto);
    Task DeleteCarAsync(int id);
}