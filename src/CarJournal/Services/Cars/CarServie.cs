using CarJournal.Domain;
using CarJournal.Infrastructure.Persistence.Cars;

namespace CarJournal.Services.Cars;

public class CarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<Car?> GetCarByIdAsync(int id)
    {
        var car = await _carRepository.GetByIdAsync(id);
        if (car == null)
        {
            throw new Exception("Car not found.");
        }
        return car;
    }

    public async Task UpdateCarAsync(int id, string model, int year)
    {
        var car = await _carRepository.GetByIdAsync(id);
        if (car == null)
        {
            throw new Exception("Car not found.");
        }

        // Бізнес-логіка для оновлення

        // потрібно доробити
        throw new Exception("доробити");
        /*  */
        await _carRepository.UpdateAsync(car);
    }

    public async Task DeleteCarAsync(int id)
    {
        var car = await _carRepository.GetByIdAsync(id);
        if (car == null)
        {
            throw new Exception("Car not found.");
        }

        await _carRepository.DeleteAsync(car);
    }
}