namespace CarJournal.Domain;

public class FuelType
{
    public FuelType(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
}