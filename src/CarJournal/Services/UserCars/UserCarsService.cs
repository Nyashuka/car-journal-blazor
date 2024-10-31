
using AutoMapper;

using CarJournal.ClientDtos;
using CarJournal.Domain;
using CarJournal.Infrastructure.Persistence.UserCars;
using CarJournal.Services.AutoMileageCalculator;
using CarJournal.Services.Mileages;

namespace CarJournal.Services.UserCars;

public class UserCarsService : IUserCarsService
{
    private readonly IUserCarsRepository _userCarRepository;

    private readonly IMapper _mapper;

    public UserCarsService(IUserCarsRepository userCarRepository, IMapper mapper)
    {
        _userCarRepository = userCarRepository;
        _mapper = mapper;
    }

    public async Task<UserCar?> GetByIdAsync(int id)
    {
        return await _userCarRepository.GetByIdAsync(id);
    }

    public async Task<List<UserCar>> GetAllAsync(int userId)
    {
        return await _userCarRepository.GetAllAsync(userId);
    }

    public async Task AddUserCarAsync(UserCar userCar)
    {
        await _userCarRepository.AddAsync(userCar);
    }

    public async Task UpdateUserCarAsync(UserCar userCar)
    {
        await _userCarRepository.UpdateAsync(userCar);
    }

    public async Task DeleteUserCarAsync(int id)
    {
        await _userCarRepository.DeleteAsync(id);
    }

    public async Task UpdateAverageMileageAsync(int userCarId, int newAverageMileage)
    {
        await _userCarRepository.UpdateAverageMileageAsync(userCarId, newAverageMileage);
    }

    public async Task UpdateCurrentMileage(int userCarId, int mileage, List<MileageRecord> mileages)
    {
        await _userCarRepository.UpdateCurrentMileage(userCarId, mileage);

        IAverageMileageCalculator averageMileageCalculator
            = new AverageMileageCalculator();

        var averageMileage = averageMileageCalculator.Calculate(
            mileages
        );

        await UpdateAverageMileageAsync(
            userCarId,
            Convert.ToInt32(averageMileage)
        );
    }
}
