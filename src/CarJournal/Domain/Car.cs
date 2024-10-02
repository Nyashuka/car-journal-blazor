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
    public string Model { get; set; } = string.Empty;
    public string Series { get; set;} = string.Empty;
    public int Year { get; set; }
    public int VendorId { get; set; }
    public int BodyTypeId { get; set; }
    public int EngineId { get; set; }
    public int GearboxId { get; set; }
    public int FuelTypeId { get; set; }
    public Vendor? Vendor { get; private set; }
    public BodyType? BodyType { get; private set; }
    public Engine? Engine { get; private set; }
    public Gearbox? Gearbox { get; private set; }
    public FuelType? FuelType { get; private set; }
}