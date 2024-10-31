using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;

namespace CarJournal.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly CarJournalDbContext _dbContext;

    public UserRepository(CarJournalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChangesAsync();
    }

    public void ChangeUserEmail(string newEmail)
    {
        throw new NotImplementedException();
    }

    public User? GetUserByEmail(string email)
    {
        return _dbContext.Users.Include(u => u.Role)
                .SingleOrDefault(user => user.Email == email);
    }

    public User? GetUserById(int id)
    {
        return _dbContext.Users
            .Include(u => u.Role)
            .SingleOrDefault(u => u.Id == id);
    }
}
