using CarJournal.Domain;

namespace CarJournal.ClientDtos;

public class CreateCarDto
{
    public int Id { get; set; }
    public string Model { get; set; } = string.Empty;
    public string Series { get; set; } = string.Empty;
    public int Year { get; set; }
    public Vendor? Vendor { get; set; }
    public BodyType? BodyType { get; set; }
    public Engine? Engine { get; set; }
    public Gearbox? Gearbox { get; set; }
    public FuelType? FuelType { get; set; }
    public int BodyTypeId { get; set; }
    public int EngineId { get; set; }
    public int GearboxId { get; set; }
    public int FuelTypeId { get; set; }
    public string DocumentationUrl { get; set; } = string.Empty;
}