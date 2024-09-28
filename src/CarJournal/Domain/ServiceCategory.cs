namespace CarJournal.Domain;

public class ServiceCategory
{
    public ServiceCategory(int id, string name)
    {
        Id = id;
        Name = name;
    }

    private ServiceCategory() {}

    public int Id { get; private set; }
    public string Name { get; private set; }
}