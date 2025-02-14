using System.ComponentModel.DataAnnotations;

namespace UserMicroservice.Interface_adapters.REST.DTOs;

public class CreateUserDto
{
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    [Required]
    public string Firstname { get; set; } = string.Empty;

    [Required]
    public string Lastname { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}