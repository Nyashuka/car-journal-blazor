using CarJournal.Domain;

namespace CarJournal.Persistence.Repositories;

public interface IUserRepository
{
    Task Add(User user);
    Task<string?> GetEmailByUserId(int userId);
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetUserById(int id);
    Task ChangeUserEmail(int userId, string newEmail);
    Task UpdateAsync(User user);
}