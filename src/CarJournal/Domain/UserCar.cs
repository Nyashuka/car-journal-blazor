namespace CarJournal.Domain;

public class UserCar
{
    public UserCar(int id, string name, int startMileage, int currentMileage, int userId, User? user, int? carId, Car? car, DateTime dateOfAdd)
    {
        Id = id;
        Name = name;
        StartMileage = startMileage;
        CurrentMileage = currentMileage;
        UserId = userId;
        User = user;
        CarId = carId;
        Car = car;
        DateOfAdd = dateOfAdd;
    }

    private UserCar(){}

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public int StartMileage { get; private set; }
    public int CurrentMileage { get; private set; }
    public int UserId { get; private set; }
    public User? User { get; private set; }
    public int? CarId { get; private set; }
    public Car? Car { get; private set;}
    public DateTime DateOfAdd { get; private set; }
}