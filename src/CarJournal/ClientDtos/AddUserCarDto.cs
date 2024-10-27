using System.ComponentModel.DataAnnotations;

using CarJournal.Domain;

namespace CarJournal.ClientDtos;

public class AddUserCarDto
{
    [Required(ErrorMessage = "This field is required")]
    [StringLength(30, ErrorMessage = "Maximum length is 30 characters")]
    public string Name { get; set; } = string.Empty;
    public int StartMileage { get; set; }
    public Car? Car { get; set; }
    public DateTime DateOfAdd { get; set; }
}