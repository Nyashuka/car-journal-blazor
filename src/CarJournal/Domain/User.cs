namespace CarJournal.Domain;

public class User
{
    public int Id { get; }
    public string Email { get; } = null!;
    public string Password { get; } = null!;
}