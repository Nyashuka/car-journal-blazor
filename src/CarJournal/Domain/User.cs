namespace CarJournal.Domain;

public class User
{
    public int Id { get; private set; }
    public string Email { get; private set; } = null!;
    public int RoleId { get; private set; }
    public Role? Role { get; private set; }
    public byte[] PasswordHash { get; private set; } = null!;
    public byte[] PasswordSalt { get; private set; } = null!;

    private User(){}

    public User(string email, byte[] passwordHash,
                byte[] passwordSalt, int roleId)
    {
        Id = 0;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        RoleId = roleId;
    }

    public User(string email, byte[] passwordHash,
                byte[] passwordSalt, int roleId, Role role) : this(email, passwordHash, passwordSalt, roleId)
    {
        Id = 0;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        RoleId = roleId;
        Role = role;
    }

    public User(int id,
                string email,
                byte[] passwordHash,
                byte[] passwordSalt, int roleId) : this(email, passwordHash, passwordSalt, roleId)
    {
        Id = id;
    }

    public User(int id,
                string email,
                byte[] passwordHash,
                byte[] passwordSalt, int roleId, Role role) : this(email, passwordHash, passwordSalt, roleId, role)
    {
        Id = id;
    }

    public void ChangeEmail(string newEmail)
    {
        Email = newEmail;
    }

    public void ChangePassword(byte[] newHash, byte[] newSalt)
    {
        PasswordHash = newHash;
        PasswordSalt = newSalt;
    }
}