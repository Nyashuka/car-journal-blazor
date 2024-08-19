public class Role
{
    public int Id { get; }
    public string Name { get; } = null!;

    private Role(){}

    public Role(string name)
    {
        Name = name;
    }

    public Role(int id, string name) : this(name)
    {
        Id = id;
    }
}