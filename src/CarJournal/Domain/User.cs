namespace CarJournal.Domain;

public class User
{
    public User(string email, string password)
    {
        Id = Guid.NewGuid();
        Email = email;
        Password = password;
    }

    public User(Guid id, string email, string password)
    {
        Id = id;
        Email = email;
        Password = password;
    }

    public Guid Id { get; }
    public string Email { get; } = null!;
    public string Password { get; } = null!;
}