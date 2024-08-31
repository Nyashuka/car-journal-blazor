namespace CarJournal.Domain;

public class Vendor
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    private Vendor() {}

    public Vendor(int id, string name)
    {
        Id = id;
        Name = name;
    }
}