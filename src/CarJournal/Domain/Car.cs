namespace CarJournal.Domain;

public class Car
{
    public Car(int id, string model, string series, int year, int vendorId, int bodyTypeId, int engineId, int gearboxId, int fuelTypeId)
    {
        Id = id;
        Model = model;
        Series = series;
        Year = year;
        VendorId = vendorId;
        BodyTypeId = bodyTypeId;
        EngineId = engineId;
        GearboxId = gearboxId;
        FuelTypeId = fuelTypeId;
    }

    private Car() {}

    public int Id { get; private set; }
    public string Model { get; private set; }
    public string Series { get; private set;}
    public int Year { get; private set; }
    public int VendorId { get; private set; }
    public int BodyTypeId { get; private set; }
    public int EngineId { get; private set; }
    public int GearboxId { get; private set; }
    public int FuelTypeId { get; private set; }
    public Vendor Vendor { get; private set; }
    public BodyType BodyType { get; private set; }
    public Engine Engine { get; private set; }
    public Gearbox Gearbox { get; private set; }
    public FuelType FuelType { get; private set; }
}