namespace UserMicroservice.Interface_adapters.REST.DTOs;

public class UserResponseDto
{
    public int UserID { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<LocationResponseDto> Locations { get; set; } = new List<LocationResponseDto>();
}
