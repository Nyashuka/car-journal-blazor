
using CarJournal.Domain;
using CarJournal.Infrastructure.Persistence.Cars;
using CarJournal.Services.DTOs;

namespace CarJournal.Services.Cars;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<IEnumerable<Car>> GetAllCarsAsync()
    {
        return await _carRepository.GetAllAsync();
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

    public async Task UpdateCarAsync(int id, UpdateCarDto updateCarDto)
    {
        var car = await _carRepository.GetByIdAsync(id);
        if (car == null)
        {
            throw new Exception("Car not found.");
        }

        car.Model = updateCarDto.Model;
        car.Series = updateCarDto.Model;
        car.Year = updateCarDto.Year;
        car.BodyTypeId = updateCarDto.BodyTypeId;
        car.EngineId = updateCarDto.EngineId;
        car.FuelTypeId = updateCarDto.FuelTypeId;
        car.GearboxId = updateCarDto.GearboxId;
        car.VendorId = updateCarDto.VendorId;

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

    public async Task<Car> CreateCarAsync(Car car)
    {
        return await _carRepository.AddAsync(car);
    }

    public async Task<IEnumerable<Car>> GetAllCarsWithDetailsAsync()
    {
        return await _carRepository.GetAllCarsWithDetails();
    }

    public async Task<List<Car>> SearchCars(string? vendor = null, string? model = null, int? year = null)
    {
        return await _carRepository.SearchCars(vendor, model, year);
    }
}