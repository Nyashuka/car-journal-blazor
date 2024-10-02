using CarJournal.Domain;

namespace CarJournal.Infrastructure.Persistence.UserCars;

public interface IUserCarsRepository
{
    Task<UserCar?> GetByIdAsync(int id);
    Task<List<UserCar>> GetAllAsync(int userId);
    Task AddAsync(UserCar userCar);
    Task UpdateAsync(UserCar userCar);
    Task DeleteAsync(int id);
}