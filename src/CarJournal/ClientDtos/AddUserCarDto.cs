using CarJournal.Domain;

namespace CarJournal.ClientDtos;

public class AddUserCarDto
{
    public string Name { get; set; } = string.Empty;
    public int StartMileage { get; set; }
    public Car? Car { get; set; }
    public DateTime DateOfAdd { get; set; }
}