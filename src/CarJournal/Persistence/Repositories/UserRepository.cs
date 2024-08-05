using CarJournal.Domain;

namespace CarJournal.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    public static readonly List<User> Users = new List<User>();

    public void Add(User user)
    {
        Users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return Users.SingleOrDefault(user => user.Email == email);
    }
}
