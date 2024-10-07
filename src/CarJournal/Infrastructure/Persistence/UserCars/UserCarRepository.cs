
using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;

namespace CarJournal.Infrastructure.Persistence.UserCars;

public class UserCarsRepository : IUserCarsRepository
{
    private readonly IDbContextFactory<CarJournalDbContext> _factory;

    public UserCarsRepository(IDbContextFactory<CarJournalDbContext> dbContext)
    {
        _factory = dbContext;
    }

    public async Task<UserCar?> GetByIdAsync(int id)
    {
        using (var context = _factory.CreateDbContext())
        {
            return await context.UserCars
                .Include(uc => uc.User)
                .Include(uc => uc.Car).AsSplitQuery()
                .FirstOrDefaultAsync(uc => uc.Id == id);
        }
    }

    public async Task<List<UserCar>> GetAllAsync(int userId)
    {
        using (var context = _factory.CreateDbContext())
        {
            return await context.UserCars
                .Where(uc => uc.UserId == userId)
                .Include(uc => uc.User)
                .Include(uc => uc.Car)
                .ToListAsync();
        }
    }

    public async Task AddAsync(UserCar userCar)
    {
        using (var context = _factory.CreateDbContext())
        {
            await context.UserCars.AddAsync(userCar);
            await context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(UserCar userCar)
    {
        using (var context = _factory.CreateDbContext())
        {
            context.UserCars.Update(userCar);
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var userCar = await GetByIdAsync(id);
        if (userCar != null)
        {
            using (var context = _factory.CreateDbContext())
            {
                context.UserCars.Remove(userCar);
                await context.SaveChangesAsync();
            }
        }
    }
}