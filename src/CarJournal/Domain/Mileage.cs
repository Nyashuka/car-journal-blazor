namespace CarJournal.Domain;

public class MileageRecord
{
    public int Id { get; private set; }
    public int Mileage { get; private set; }
    public bool IsAutomatic { get; private set; }
    public int UserCarId { get; private set; }
    public UserCar UserCar { get; private set; }
}