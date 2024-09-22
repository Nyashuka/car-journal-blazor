namespace CarJournal.Domain;

public class ServiceRecord
{
    public int Id { get; set; }
    public string Title { get; private set; }
    public int ServiceCategoryId { get; private set; }
    public int UserCarId { get; private set; }
    public int Mileage { get; private set; }
    public int Price { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; }
    public ServiceCategory ServiceCategory { get; private set; }
    public UserCar UserCar { get; private set; }
}