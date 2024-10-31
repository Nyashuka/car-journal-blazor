using CarJournal.ClientDtos;
using CarJournal.Domain;

namespace CarJournal.Services.UserCars;

public interface IUserCarsService
{
    Task<UserCar?> GetByIdAsync(int id);
    Task<List<UserCar>> GetAllAsync(int userId);
    Task AddUserCarAsync(UserCar userCar);
    Task UpdateUserCarAsync(UserCar userCar);
    Task DeleteUserCarAsync(int id);
    Task UpdateAverageMileageAsync(int userCarId, int newAverageMileage);
    Task UpdateCurrentMileage(int userCarId, int mileage, List<MileageRecord> mileages);
}