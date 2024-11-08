
using CarJournal.ClientDtos;
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

    public async Task UpdateCarAsync(int id, CreateCarDto updateCarDto)
    {
        var car = await _carRepository.GetByIdAsync(id);
        if (car == null)
        {
            throw new Exception("Car not found.");
        }

        car.Model = updateCarDto.Model;
        car.Series = updateCarDto.Series;
        car.Year = updateCarDto.Year;
        car.BodyTypeId = updateCarDto.BodyType.Id;
        car.EngineId = updateCarDto.Engine.Id;
        car.FuelTypeId = updateCarDto.FuelType.Id;
        car.GearboxId = updateCarDto.Gearbox.Id;
        car.VendorId = updateCarDto.Vendor.Id;
        car.DocumentationUrl = updateCarDto.DocumentationUrl;

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

    public async Task<List<Car>> SearchCars(string? vendor = null, string? series = null, int? year = null)
    {
        return await _carRepository.SearchCars(vendor, series, year);
    }
}