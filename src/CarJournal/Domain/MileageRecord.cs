namespace CarJournal.Domain;

public class MileageRecord
{
    public MileageRecord(int id, int mileage, bool isAutomatic, int userCarId, UserCar? userCar, DateTime updatedTime)
    {
        Id = id;
        Mileage = mileage;
        IsAutomatic = isAutomatic;
        UserCarId = userCarId;
        UserCar = userCar;
        UpdatedAt = updatedTime;
    }

    private MileageRecord() {}

    public int Id { get; private set; }
    public int Mileage { get; private set; }
    public bool IsAutomatic { get; private set; }
    public int UserCarId { get; private set; }
    public UserCar? UserCar { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public void UpdateData(int mileage, DateTime dateTime)
    {
        Mileage = mileage;
        UpdatedAt = dateTime.ToUniversalTime();
    }

    public void UpdateDate()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}