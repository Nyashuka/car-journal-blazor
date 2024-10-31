using CarJournal.Domain;

namespace CarJournal.Persistence.Repositories;

public interface IUserRepository
{
    public void Add(User user);
    public User? GetUserByEmail(string email);
    User? GetUserById(int id);
    void ChangeUserEmail(string newEmail);
}