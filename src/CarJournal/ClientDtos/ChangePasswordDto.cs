using System.ComponentModel.DataAnnotations;

namespace CarJournal.ClientDtos;

public class ChangePasswordDto
{
    [Required]
    [StringLength(30, ErrorMessage = "Password must be at least 4 characters long.", MinimumLength = 4)]
    public string OldPassword { get; set; } = string.Empty;

    [Required]
    [StringLength(30, ErrorMessage = "Password must be at least 4 characters long.", MinimumLength = 4)]
    public string Password { get; set; } = string.Empty;

    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = string.Empty;
}