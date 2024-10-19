namespace CarJournal.Domain;

public class UserCar
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public int StartMileage { get; private set; }
    public int CurrentMileage { get; private set; }
    public int AverageMileage { get; private set; }
    public int UserId { get; private set; }
    public User? User { get; private set; }
    public int? CarId { get; private set; }
    public Car? Car { get; private set;}
    public DateTime DateOfAdd { get; private set; }

    private UserCar(){}

    public UserCar(int id, string name, int startMileage, int currentMileage, int averageMileage, int userId, User? user, int? carId, Car? car, DateTime dateOfAdd)
    {
        Id = id;
        Name = name;
        StartMileage = startMileage;
        CurrentMileage = currentMileage;
        AverageMileage = averageMileage;
        UserId = userId;
        User = user;
        CarId = carId;
        Car = car;
        DateOfAdd = dateOfAdd;
    }

    public void UpdateAverageMileage(int mileage)
    {
        if(mileage < 0)
            return;

        AverageMileage = mileage;
    }

    public void UpdateCurrentMileage(int mileage)
    {
        if(mileage < StartMileage || mileage < CurrentMileage)
            return;

        CurrentMileage = mileage;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }
}