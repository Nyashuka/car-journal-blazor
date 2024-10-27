using CarJournal.Domain;

namespace CarJournal.ClientDtos;

public class UpdateUserCarDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int StartMileage { get; set; }
    public int CurrentMileage { get; set; }
    public int AverageMileage { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public int? CarId { get; set; }
    public Car? Car { get; set;}
    public DateTime DateOfAdd { get; set; }
}