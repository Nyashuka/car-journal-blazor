namespace CarJournal.Domain;

public class ServiceRecord
{
    public ServiceRecord(int id, string title, int serviceCategoryId, int userCarId, int mileage, int price, string description, DateTime dateOfService, ServiceCategory? serviceCategory, UserCar? userCar)
    {
        Id = id;
        Title = title;
        ServiceCategoryId = serviceCategoryId;
        UserCarId = userCarId;
        Mileage = mileage;
        Price = price;
        Description = description;
        DateOfService = dateOfService;
        ServiceCategory = serviceCategory;
        UserCar = userCar;
    }

    private ServiceRecord() {}

    public int Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public int ServiceCategoryId { get; private set; }
    public int UserCarId { get; private set; }
    public int Mileage { get; private set; }
    public int Price { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public DateTime DateOfService { get; private set; }
    public ServiceCategory? ServiceCategory { get; private set; }
    public UserCar? UserCar { get; private set; }
}