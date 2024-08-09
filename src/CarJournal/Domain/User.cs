namespace CarJournal.Domain;

public class User
{
    public int Id { get; private set; }
    public string Email { get; private set; } = null!;
    public int RoleId { get; private set; }
    public byte[] PasswordHash { get; private set; } = null!;
    public byte[] PasswordSalt { get; private set; } = null!;

    public User(string email, int roleId, byte[] passwordHash,
                byte[] passwordSalt)
    {
        Id = 0;
        Email = email;
        RoleId = roleId;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
   }

    public User(int id,
                string email,
                int roleId,
                byte[] passwordHash,
                byte[] passwordSalt) : this(email, roleId, passwordHash, passwordSalt)
    {
        Id = id;
    }
}