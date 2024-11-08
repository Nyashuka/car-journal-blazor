using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace CarJournal.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbContextFactory<CarJournalDbContext> _dbFactory;

    public UserRepository(IDbContextFactory<CarJournalDbContext> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task Add(User user)
    {
        using(var dbContext = _dbFactory.CreateDbContext())
        {
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task ChangeUserEmail(int userId, string newEmail)
    {
        using(var dbContext = _dbFactory.CreateDbContext())
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user is User)
            {
                user.ChangeEmail(newEmail);
                dbContext.Users.Update(user);

                await dbContext.SaveChangesAsync();
            }
        }
    }

    public async Task<string?> GetEmailByUserId(int userId)
    {
        using(var dbContext = _dbFactory.CreateDbContext())
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            return user?.Email;
        }
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        using(var dbContext = _dbFactory.CreateDbContext())
        {
            return await dbContext.Users.Include(u => u.Role)
                .SingleOrDefaultAsync(user => user.Email == email);
        }
    }

    public async Task<User?> GetUserById(int id)
    {
        using(var dbContext = _dbFactory.CreateDbContext())
        {
            return await dbContext.Users
                .Include(u => u.Role)
                .SingleOrDefaultAsync(u => u.Id == id);
        }
    }

    public async Task UpdateAsync(User user)
    {
        using(var dbContext = _dbFactory.CreateDbContext())
        {
            dbContext.Users.Update(user);

            await dbContext.SaveChangesAsync();
        }
    }
}
