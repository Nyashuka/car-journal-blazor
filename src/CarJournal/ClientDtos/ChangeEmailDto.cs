using System.ComponentModel.DataAnnotations;

using CarJournal.Attributes;

namespace CarJournal.ClientDtos;

public class ChangeEmailDto
{
    [Required]
    [MyEmailAddress]
    public string Email { get; set; } = string.Empty;
}