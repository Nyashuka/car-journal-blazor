namespace CarJournal.Domain;

public class Manufacturer
{
    public int Id { get; }
    public string Name { get; }

    public Manufacturer(int id, string name)
    {
        Id = id;
        Name = name;
    }
}