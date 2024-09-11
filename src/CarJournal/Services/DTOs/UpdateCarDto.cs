namespace CarJournal.Services.DTOs;

public class UpdateCarDto
{
    public string Model { get; set; }
    public string Series { get; set; }
    public int Year { get; set; }
    public int VendorId { get; set; }
    public int BodyTypeId { get; set; }
    public int EngineId { get; set; }
    public int GearboxId { get; set; }
    public int FuelTypeId { get; set; }
}