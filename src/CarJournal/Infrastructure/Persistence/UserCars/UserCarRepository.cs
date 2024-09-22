
using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;

namespace CarJournal.Infrastructure.Persistence.UserCars;

public class UserCarsRepository : IUserCarsRepository
{
    private readonly CarJournalDbContext _context;
    private readonly DbSet<UserCar> _userCars;

    public UserCarsRepository(CarJournalDbContext dbContext)
    {
        _context = dbContext;
        _userCars = _context.UserCars;
    }

    public async Task<UserCar?> GetByIdAsync(int id)
    {
        return await _context.UserCars
            .Include(uc => uc.User)
            .Include(uc => uc.Car)
            .FirstOrDefaultAsync(uc => uc.Id == id);
    }

    public async Task<List<UserCar>> GetAllAsync(int userId)
    {
        return await _context.UserCars
            .Where(uc => uc.UserId == userId)
            .Include(uc => uc.User)
            .Include(uc => uc.Car)
            .ToListAsync();
    }

    public async Task AddAsync(UserCar userCar)
    {
        await _context.UserCars.AddAsync(userCar);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(UserCar userCar)
    {
        _context.UserCars.Update(userCar);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var userCar = await GetByIdAsync(id);
        if (userCar != null)
        {
            _context.UserCars.Remove(userCar);
            await _context.SaveChangesAsync();
        }
    }
}