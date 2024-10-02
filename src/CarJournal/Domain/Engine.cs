namespace CarJournal.Domain;

public class Engine
{
    public int Id { get; private set; }
    public string Model { get; private set; } = string.Empty;
    public float EngineSize { get; private set; }

    private Engine(){}
    
    public Engine(int id, string model, float engineSize)
    {
        Id = id;
        Model = model;
        EngineSize = engineSize;
    }
}