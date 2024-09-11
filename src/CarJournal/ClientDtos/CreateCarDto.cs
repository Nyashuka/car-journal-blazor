using CarJournal.Domain;

namespace CarJournal.ClientDtos;

public class CreateCarDto
{
    public string Model { get; set; }
    public string Series { get; set; }
    public int Year { get; set; }
    public Vendor Vendor { get; set; }
    public BodyType BodyType { get; set; }
    public Engine Engine { get; set; }
    public Gearbox Gearbox { get; set; }
    public FuelType FuelType { get; set; }
    public int BodyTypeId { get; set; }
    public int EngineId { get; set; }
    public int GearboxId { get; set; }
    public int FuelTypeId { get; set; }
}