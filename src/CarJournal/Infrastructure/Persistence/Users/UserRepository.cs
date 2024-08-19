using CarJournal.Domain;

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

    public User? GetUserByEmail(string email)
    {
        return _dbContext.Users.SingleOrDefault(user => user.Email == email);
    }
}
