using CarJournal.Domain;

namespace CarJournal.ClientDtos;

public class AddServiceDto
{
    public string Title { get; set; } = string.Empty;
    public int Mileage { get; set; }
    public int Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime? DateOfService { get; set; } = DateTime.Now;
    public ServiceCategory? ServiceCategory { get; set; }
    public int UserCarId { get; set; }
}